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

        // Add activities

        public Activity addActivity(Activity a)
        {
            // TODO: only allow group values: "kapoenen", "kawellen", "jonggivers", "givers", "jins, "leiding", "iedereen"
            dbContext.Activities.Add(a);
            dbContext.SaveChanges();
            return a;
        }

        // Delete activities

        public Activity deleteActivityFromId(int id)
        {
            Activity a = dbContext.Activities.Find(id);
            if (a != null)
            {
                dbContext.Activities.Remove(a);
                dbContext.SaveChanges();
            }
            return a;
        }

        // Update activities

        public Activity updateActivityFromId(int id, Activity a)
        {
            Activity activity = dbContext.Activities.Find(id);
            if (activity != null)
            {
                activity.updateFrom(a);
                dbContext.Activities.Update(activity);
                dbContext.SaveChanges();
            }
            return activity;
        }
    }
}