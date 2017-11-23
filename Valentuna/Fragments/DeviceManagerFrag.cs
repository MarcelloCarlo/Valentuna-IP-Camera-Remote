using Android.OS;
using Android.Support.V4.App;
using Android.Views;


namespace Valentuna.Fragments
{
    public class DeviceManager : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public static DeviceManager NewInstance()
        {
            var deviceManager = new DeviceManager { Arguments = new Bundle() };
            return deviceManager;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var DevMangerView = inflater.Inflate(Resource.Layout.DeviceManagerFrag, container, false);


            return DevMangerView;

           
            

        }
    }
}