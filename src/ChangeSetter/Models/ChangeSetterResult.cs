namespace ChangeSetter.Models
{
    public class ChangeSetterResult<T>
    {
        public bool HasChanges { get; set; }
        public T Value { get; set; }
    }
}
