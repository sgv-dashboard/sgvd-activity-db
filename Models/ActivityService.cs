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
                activity = new Activity(id, "idNotFound");
            }
            return activity;
        }

        public List<Activity> getActivities()
        {
            return dbContext.Activities.ToList();
        }

        public bool doesActivityWithIdExist(int id)
        {
            return dbContext.Activities.Any(a => a.id == id);
        }

        public List<Activity> getActivitiesWithTitle(string title)
        {
            var activities = dbContext.Activities.Where(a => a.title == title);
            return activities.ToList();
        }

        public List<Activity> getActivitiesOnDate(DateTime date)
        {
            var activities = dbContext.Activities.Where(a => a.dateTime.Date == date.Date);
            return activities.ToList();
        }

        public List<Activity> getActivitiesOfGroup(string group)
        {
            var activities = dbContext.Activities.Where(a => a.group == group);
            return activities.ToList();
        }
    }
}