namespace lezioniEcommerce.API.DTO
{
    public class WRITE_USER_DTO
    {
        public string USER_USERNAME { get; set; }
        public string USER_FIRSTNAME { get; set; }
        public string USER_LASTNAME { get; set; }
        public string USER_PASSWORD { get; set; }
        public string USER_EMAIL { get; set; }
        public string TOKEN { get; set; }
        public int CART_ID { get; set; }
    }
}
