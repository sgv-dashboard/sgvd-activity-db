using System.ServiceModel;
namespace Models
{
    [ServiceContract]
    public interface IActivityService
    {
        // Get activities

        [OperationContract]
        public Activity getActivityFromId(int id);

        [OperationContract]
        public List<Activity> getActivitiesWithTitle(string title);

        [OperationContract]
        public List<Activity> getActivitiesOnDate(DateTime date);

        [OperationContract]
        public List<Activity> getActivitiesFromDate(DateTime date);

        [OperationContract]
        public List<Activity> getActivities();

        [OperationContract]
        public List<Activity> getActivitiesOfGroup(string group);

        [OperationContract]
        public bool doesActivityWithIdExist(int id);

        // Add activities

        [OperationContract]
        public Activity addActivity(Activity a);

        // Delete activities

        [OperationContract]
        public Activity deleteActivityFromId(int id);

        // Update activities

        [OperationContract]
        public Activity updateActivityFromId(int id, Activity a);
    }
}
