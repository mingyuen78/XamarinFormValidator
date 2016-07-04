using Android.App;
using Android.Widget;
using Android.OS;
using ValidationForm.Com.IsGoodStuff;
using System;
using Android.Graphics;
using System.Collections.Generic;

namespace ValidationForm.Droid
{
	[Activity(Label = "Validation Form", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		
		FormObject[] MyTextUI = new FormObject[6];

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Main);

			/* Below are the implementation of the Validator in action. 
			 * For ease of reference we will store a reference of the UI in array */

			/* Notice, that validator requires some additional attribute to store it's validation criteria */
			/* to Store validation criteria for each inputText, I create a class FormObject and use Criteria property */
			MyTextUI[0] = new FormObject();
			MyTextUI[0].FormObj = FindViewById<EditText>(Resource.Id.txtFullName);
			MyTextUI[0].Criteria = (string)Validator.Criteria.NOTNULL;

			MyTextUI[1] = new FormObject();
			MyTextUI[1].FormObj = FindViewById<EditText>(Resource.Id.txtAlias);
			MyTextUI[1].Criteria = (string)Validator.Criteria.NONE;

			MyTextUI[2] = new FormObject();
			MyTextUI[2].FormObj = FindViewById<EditText>(Resource.Id.txtEmail);
			MyTextUI[2].Criteria = (string)Validator.Criteria.EMAIL;

			MyTextUI[3] = new FormObject();
			MyTextUI[3].FormObj = FindViewById<EditText>(Resource.Id.txtAge);
			MyTextUI[3].Criteria = (string)Validator.Criteria.INTEGERONLY;

			MyTextUI[4] = new FormObject();
			MyTextUI[4].FormObj = FindViewById<EditText>(Resource.Id.txtMobileNumber);
			MyTextUI[4].Criteria = (string)Validator.Criteria.MOBILE_NUMBER;

			var _Custom_RegExp = "^[a-zA-Z][0-9]{4}$";

			MyTextUI[5] = new FormObject();
			MyTextUI[5].FormObj = FindViewById<EditText>(Resource.Id.txtEmployeeCode);
			MyTextUI[5].Criteria = (string) _Custom_RegExp;

			var btnSubmit = FindViewById<Button>(Resource.Id.btnSubmit);

			btnSubmit.Click += delegate {
				int resultCount = 0;
				var ValidateEngine = new Validator();

				this.ResetFieldErrorState();

				for (var i = 0; i < MyTextUI.Length; i++)
				{
					if (!ValidateEngine.CheckFor(MyTextUI[i].FormObj.Text, (string)MyTextUI[i].Criteria))
					{
						// Note: If CheckFor returns false means there's an error.
						// You can also take this opportunity to highlight the error field.
						// or use HintText to display the cause of error etc.
						MyTextUI[i].FormObj.SetBackgroundColor(Color.Pink);
						MyTextUI[i].FormObj.SetHintTextColor(Color.Maroon);
						MyTextUI[i].FormObj.Text = "";
						resultCount++;
					}

				}

				if (resultCount != 0) {
					Toast.MakeText(this,"Cannot proceed : " + resultCount + " errors found!",ToastLength.Long).Show();
				} else {
					Toast.MakeText(this, "OK! All Good. Proceed : " + resultCount + " errors found!", ToastLength.Long).Show();
				}

			};
		}

		private void ResetFieldErrorState() {
			for (var i = 0; i < MyTextUI.Length; i++)
			{
				MyTextUI[i].FormObj.SetBackgroundColor(Color.White);
				MyTextUI[i].FormObj.SetHintTextColor(Color.Silver);
			}
		}
	}

	public class FormObject
	{
		public EditText FormObj { set; get; }
		public string Criteria { set; get; }
	}
}


