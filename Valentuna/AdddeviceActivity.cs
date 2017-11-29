using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Valentuna.Fragments;

namespace Valentuna
{
    [Activity(Label = "AdddeviceActivity")]
    public class AdddeviceActivity : AppCompatActivity 
    {
        private const int AutoDiscoverDialog = 1;
        private const int DeviceManualDialog = 2;
        string IPaddr = String.Empty;
        string IPport = String.Empty;
        string Username = String.Empty;
        string Password = String.Empty;

		protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            int pos = Intent.GetIntExtra("buttonClicked",0);
            if (pos == 1)
            {
                ShowDialog(AutoDiscoverDialog);
            }
            else
            if (pos == 2)
            {
                ShowDialog(DeviceManualDialog);
            }



        }

        protected override Dialog OnCreateDialog(int id, Bundle args)
        {
            switch (id)
            {
                case AutoDiscoverDialog:
                    {
                        var builder = new Android.Support.V7.App.AlertDialog.Builder(this);
                        builder.SetIconAttribute(Android.Resource.Attribute.AlertDialogIcon);
                        builder.SetTitle(Resource.String.list_dialog_title);
                        builder.SetSingleChoiceItems(Resource.Array.list_dialog_items, 0, ListClicked);

                        builder.SetPositiveButton(Resource.String.dialog_login, OkClicked);
                        builder.SetNegativeButton(Resource.String.dialog_cancel, CancelClicked);

                        return builder.Create();
                    }
                case DeviceManualDialog:
                    {
                        var customView = LayoutInflater.Inflate(Resource.Layout.AddDeviceManualDialog, null);

                        var builder = new Android.Support.V7.App.AlertDialog.Builder(this);
                        builder.SetView(customView);
                        builder.SetPositiveButton(Resource.String.dialog_login, OkClicked);
                        builder.SetNegativeButton(Resource.String.dialog_cancel, CancelClicked);

                        return builder.Create();
                    }
            }

            return base.OnCreateDialog(id, args);
        }
        private void OkClicked(object sender, DialogClickEventArgs args)
        {

            var dialog = (Android.Support.V7.App.AlertDialog)sender;
            var  CamIPAddresstxt = (EditText)dialog.FindViewById(Resource.Id.CamIPAddresstxt);
            var CamIPPorttxt = (EditText)dialog.FindViewById(Resource.Id.CamIPPorttxt);
            var CamUsernametxt = (EditText)dialog.FindViewById(Resource.Id.CamUsernametxt);
            var CamPasswordtxt = (EditText)dialog.FindViewById(Resource.Id.CamPasswordtxt);
            IPaddr = CamIPAddresstxt.Text;
            IPport = CamIPPorttxt.Text;
            Username = CamUsernametxt.Text;
            Password = CamPasswordtxt.Text;

            if (String.IsNullOrWhiteSpace(IPaddr) || String.IsNullOrWhiteSpace(IPport) || String.IsNullOrWhiteSpace(Username) || String.IsNullOrWhiteSpace(Password))
            {
                Toast.MakeText(this, Resource.String.login_success, ToastLength.Short).Show();
                StartActivity(typeof(LivePlay));
                //var myExhibitHistoryActivity = new Intent(Activity, typeof(LivePlay));
                //StartActivity(LivePlay);
            }
            else
            {
                Toast.MakeText(this, Resource.String.login_failed, ToastLength.Short).Show();
            }
            //Toast.MakeText(this, (username != null ?
            //    string.Format("Username: {0} ", username.Text) : "") +
            //    (password != null ? string.Format("Password: {0}", password.Text) : ""), ToastLength.Short).Show();
            
        }

        private void CancelClicked(object sender, DialogClickEventArgs args)
        {
            DevHome.NewInstance();
        }

        private void ListClicked(object sender, DialogClickEventArgs args)
        {
            var items = Resources.GetStringArray(Resource.Array.list_dialog_items);

            Toast.MakeText(this, string.Format("You've selected: {0}, {1}", args.Which, items[args.Which]), ToastLength.Short).Show();
        }

    }
}