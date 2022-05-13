namespace Admin.Domain.Models.Response
{
    public class BaseRs
    {
        public dynamic content { get; set; }
        public BaseError Error { get; set; } = null;

        public void SetError(Exception ex)
        {
            this.Error = new BaseError(ex);
        }
        public void SetError(List<string> msgs)
        {
            this.Error = new BaseError(msgs);
        }
        public void SetError(IEnumerable<string> msgs)
        {
            this.Error = new BaseError(msgs.ToList());
        }
        public void SetError(string msg)
        {
            this.Error = new BaseError(new List<string>() { msg });
        }
    }

    public class BaseRs<T>
    {
        public T Content { get; set; } = default(T);
        public BaseError Error { get; set; } = null;

        public void SetError(Exception ex)
        {
            this.Error = new BaseError(ex);
        }
        public void SetError(List<string> msgs)
        {
            this.Error = new BaseError(msgs);
        }
        public void SetError(IEnumerable<string> msgs)
        {
            this.Error = new BaseError(msgs.ToList());
        }
        public void SetError(string msg)
        {
            this.Error = new BaseError(new List<string>() { msg });
        }
    }

    public class BaseError
    {
        public BaseError(string msg)
        {
            this.message = new List<string>();
            this.message.Add(msg);
        }
        public BaseError(List<string> msgs)
        {
            this.message = msgs;
        }

        public BaseError(Exception ex)
        {
            this.message.Add(ex.Message);
            //if (System.Diagnostics.Debugger.IsAttached)
            //{
            //    this.description = ex.StackTrace;
            //    this.description += ex.InnerException?.Message;
            //}
        }

        public List<string> message { get; } = new List<string>();
        public string description { get; set; } = null;
    }
}