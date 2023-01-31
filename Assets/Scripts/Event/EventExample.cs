using UnityEngine;

namespace Event
{
    public class EventExample
    {
        public EasyEvent<string> testStr = new EasyEvent<string>();

        public void Register()
        {
            testStr.Register((str) =>
            {
                Debug.Log(str);
            }).UnRegisterWhenGameObjectDestroyed(new GameObject());//这个gameobject为创建的事件所属的gameobject，一般都是this.gameobject
        }

        public void Trigger()
        {
            testStr.Trigger("Hello, ggj");
        }
    }
}