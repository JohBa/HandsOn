using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using AIT_XamarinCommunityEventService.DataObjects;
using AIT_XamarinCommunityEventService.Models;
using System.Collections.Generic;
using Microsoft.Azure.NotificationHubs;
using Microsoft.Azure.Mobile.Server.Config;

namespace AIT_XamarinCommunityEventService.Controllers
{
    public class TodoItemController : TableController<TodoItem>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            AIT_XamarinCommunityEventContext context = new AIT_XamarinCommunityEventContext();
            DomainManager = new EntityDomainManager<TodoItem>(context, Request);
        }

        [Authorize]
        // GET tables/TodoItem
        public IQueryable<TodoItem> GetAllTodoItems()
        {
            return Query();
        }

        [Authorize]
        // GET tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<TodoItem> GetTodoItem(string id)
        {
            return Lookup(id);
        }

        [Authorize]
        // PATCH tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<TodoItem> PatchTodoItem(string id, Delta<TodoItem> patch)
        {
            return UpdateAsync(id, patch);
        }

        [Authorize]
        // POST tables/TodoItem
        public async Task<IHttpActionResult> PostTodoItem(TodoItem item)
        {
            TodoItem current = await InsertAsync(item);

            // Get the settings for the server project.
            HttpConfiguration config = this.Configuration;
            MobileAppSettingsDictionary settings =
                this.Configuration.GetMobileAppSettingsProvider().GetMobileAppSettings();

            // Get the Notification Hubs credentials for the Mobile App.
            string notificationHubName = settings.NotificationHubName;
            string notificationHubConnection = settings
                .Connections[MobileAppSettingsKeys.NotificationHubConnectionString].ConnectionString;

            // Create a new Notification Hub client.
            NotificationHubClient hub = NotificationHubClient
            .CreateClientFromConnectionString(notificationHubConnection, notificationHubName);

            // Sending the message so that all template registrations that contain "messageParam"
            // will receive the notifications. This includes APNS, GCM, WNS, and MPNS template registrations.
            Dictionary<string, string> templateParams = new Dictionary<string, string>();
            templateParams["messageParam"] = item.Text + " was added to the list.";

            try
            {
                // Send the push notification and log the results.
                var result = await hub.SendTemplateNotificationAsync(templateParams);

                // Write the success result to the logs.
                config.Services.GetTraceWriter().Info(result.State.ToString());
            }
            catch (System.Exception ex)
            {
                // Write the failure result to the logs.
                config.Services.GetTraceWriter()
                    .Error(ex.Message, null, "Push.SendAsync Error");
            }

            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // [Authorize]
        // DELETE tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteTodoItem(string id)
        {
            return DeleteAsync(id);
        }
    }
}