using System.ServiceModel;
namespace Models
{
    [ServiceContract]
    public interface IActivityService
    {
        [OperationContract]
        public Activity getActivityFromId(int id);

        [OperationContract]
        public List<Activity> getActivitiesWithTitle(string title);

        [OperationContract]
        public List<Activity> getActivitiesOnDate(DateTime date);

        [OperationContract]
        public List<Activity> getActivities();

        [OperationContract]
        public List<Activity> getActivitiesOfGroup(string group);

        [OperationContract]
        public bool doesActivityWithIdExist(int id);
    }
}
