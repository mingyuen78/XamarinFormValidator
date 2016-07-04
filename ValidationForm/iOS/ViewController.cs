using System;
using ValidationForm.Com.IsGoodStuff;
using UIKit;
using Foundation;

namespace ValidationForm.iOS
{
	public partial class ViewController : UIViewController
	{

		public ViewController(IntPtr handle) : base(handle){
		}



		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			/* We assign criterias for validation into array of FormObject */
			/* You can also use dictionary and 2 dimentional arrays or extend */
			/* UITextField to have some public string property */
			FormObject[] MyTextUI = new FormObject[6];

			MyTextUI[0] = new FormObject();
			MyTextUI[0].FormObj = txtFullName;
			MyTextUI[0].Criteria = Validator.Criteria.NOTNULL;

			MyTextUI[1] = new FormObject();
			MyTextUI[1].FormObj = txtAlias;
			MyTextUI[1].Criteria = Validator.Criteria.NONE;

			MyTextUI[2] = new FormObject();
			MyTextUI[2].FormObj = txtEmail;
			MyTextUI[2].Criteria = Validator.Criteria.EMAIL;

			MyTextUI[3] = new FormObject();
			MyTextUI[3].FormObj = txtAge;
			MyTextUI[3].Criteria = Validator.Criteria.INTEGERONLY;

			MyTextUI[4] = new FormObject();
			MyTextUI[4].FormObj = txtMobileNumber;
			MyTextUI[4].Criteria = Validator.Criteria.MOBILE_NUMBER;

			var _Custom_RegExp = "^[a-zA-Z][0-9]{4}$";
			MyTextUI[5] = new FormObject();
			MyTextUI[5].FormObj = txtEmployeeCode;
			MyTextUI[5].Criteria = _Custom_RegExp;

			btnSubmit.TouchUpInside += delegate {
				int resultCount = 0;
				var ValidateEngine = new Validator();

				this.ResetFieldErrorState(MyTextUI);

				for (var i = 0; i < MyTextUI.Length; i++)
				{
					if (!ValidateEngine.CheckFor(MyTextUI[i].FormObj.Text, (string)MyTextUI[i].Criteria))
					{
						// Note: If CheckFor returns false means there's an error.
						// You can also take this opportunity to highlight the error field.
						// or use HintText to display the cause of error etc.
						MyTextUI[i].FormObj.BackgroundColor = UIColor.FromRGB(255, 192, 203);
						NSAttributedString PlaceholderString = new NSAttributedString(
							MyTextUI[i].FormObj.Placeholder,
							new UIStringAttributes(){
								ForegroundColor = UIColor.FromRGB(128, 0, 0)
							}
						);
						MyTextUI[i].FormObj.AttributedPlaceholder = PlaceholderString;
						MyTextUI[i].FormObj.Text = "";
						resultCount++;
					}
				}

				if (resultCount != 0)
				{
					UIAlertView _MsgDialog = new UIAlertView("Alert", "Cannot proceed : " + resultCount + " errors found!", null, "Ok", null);
					_MsgDialog.Show();
				}
				else {
					UIAlertView _MsgDialog = new UIAlertView("Alert", "OK! All Good. Proceed : " + resultCount + " errors found!", null, "Ok", null);
					_MsgDialog.Show();
				}

			};
		}

		public void ResetFieldErrorState(FormObject[] _MyTextUI)
		{
			for (var i = 0; i < _MyTextUI.Length; i++){ 
				_MyTextUI[i].FormObj.BackgroundColor = UIColor.FromRGB(255, 255, 255);
			}
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.		
		}
	}

	public class FormObject
	{
		// in IOS 
		public UITextField FormObj { set; get; }
		public string Criteria { set; get; }
	}
}
