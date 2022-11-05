namespace SigmaJobApplicantion.Controllers.Helper.Interfaces;

public interface IExeclRepository<T> where T:class
{
    public string RecordFile { get; set; }

    public  void AddEntity(T entity);
    public bool UpdateEnttity(T entity);

    public void AddAllEntity(List<T> entities);
}