using Newtonsoft.Json;

namespace Shopping.Insfrastructure
{
    public static class SessionExtension
    {
        public static void SetJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T getJson<T>(this ISession session, string key)
        {
            var sessionData = session.GetString(key);
            return sessionData == null?default(T):JsonConvert.DeserializeObject<T>(sessionData);
        }    
    }
}
