namespace filmsite.Models
{
    public class WrapperUserObject
    {
        public UserLoginObject UserLoginObject { get; set; }

        public UserObject UserRegistrationObject { get; set; }

        public WrapperUserObject() { }

        public WrapperUserObject(string message, bool isLogin)
        {
            //Dem ekstra bool-verdien er bare for å kunne skille de to konstruktørene
            this.UserLoginObject = new UserLoginObject();
            this.UserLoginObject.ErrorState = message;
        }

        public WrapperUserObject(string message)
        {
            this.UserRegistrationObject = new UserObject();
            this.UserRegistrationObject.ErrorState = message;
        }
    }
}