using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Telefono
{
    [Activity(Label = "PhoneApp", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.MainPage);
            var PhoneNumberText = FindViewById<EditText>(Resource.Id.txtNumero);
            var TranslateButton = FindViewById<Button>(Resource.Id.btnConvertir);
            var CallButton = FindViewById<Button>(Resource.Id.btnLlamar);
            var TextNumbre = FindViewById<TextView>(Resource.Id.lblConvertido);
            CallButton.Enabled = false;
            var TranslatedNumber = string.Empty;
            TranslateButton.Click += (object sender, System.EventArgs e) => {
                var Translator = new PhoneTranslator();
                TranslatedNumber = Translator.ToNumber(PhoneNumberText.Text);
                if (!string.IsNullOrWhiteSpace(TranslatedNumber))
                {
                    CallButton.Enabled = true;
                    CallButton.Text = "Call " + TranslatedNumber;
                    TextNumbre.Text = TranslatedNumber;
                }
                else
                {
                }
            };
            CallButton.Click += (object sender, System.EventArgs e) => {
                // Intentar marcar el número telefónico
                var CallDialog = new global::Android.App.AlertDialog.Builder(this);
                CallDialog.SetMessage($"Llamar al número {TranslatedNumber}?");
                CallDialog.SetNeutralButton("Llamar", delegate
                {
                    // Crear un intento para marcar el número telefónico
                    var CallIntent = new global::Android.Content.Intent(global::Android.Content.Intent.ActionCall);
                    CallIntent.SetData(global::Android.Net.Uri.Parse($"tel:{TranslatedNumber}"));
                    StartActivity(CallIntent);
                });
                CallDialog.SetNegativeButton("Cancelar", delegate { });
                // Mostrar el cuadro de diálogo al usuario y esperar una respue CallDialog.Show();
            };

        }
    }
}

