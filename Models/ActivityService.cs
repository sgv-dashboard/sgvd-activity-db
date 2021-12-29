using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class ActivityService : IActivityService
    {

        private readonly ActivityContext dbContext;

        public ActivityService(ActivityContext context)
        {
            dbContext = context;
        }

        public Activity getActivityFromId(int id)
        {
            Activity activity = dbContext.Activities.Find(id);
            if (activity == null)
            {
                activity = new Activity(id, "idNotFound", DateTime.Now);
            }
            return activity;
        }
        /*
        // SOURCE: https://entityframeworkcore.com/knowledge-base/51939451/how-to-use-a-database-context-in-a-singleton-service-
        private readonly IServiceScopeFactory scopeFactory;

        public ActivityService(IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;
        }
        public Activity getActivityFromId(int id)
        {
            Activity activity; //= new Activity(id, "test evenement", DateTime.Now);
            using (var scope = scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<DbContext>();

                activity = dbContext.Find<Activity>(id);
            }

            return activity;
        }*/
    }
}