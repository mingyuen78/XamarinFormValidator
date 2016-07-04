using System;
using System.Text.RegularExpressions;

namespace ValidationForm.Com.IsGoodStuff
{
	public class Validator
	{

		public static class Criteria
		{
			public const string NOTNULL = "NOTNULL";
			public const string INTEGERONLY = "INTEGERONLY";
			public const string EMAIL = "EMAIL";
			public const string FLOATONLY = "FLOATONLY";
			public const string MINIMUMCHAR6 = "MINCHAR6";
			public const string NONE = "NONE";
			public const string MOBILE_NUMBER = "LOCALMOBILE";
		}

		public bool _return = false;
		Regex _objReg;

		public Validator (){}
		public bool CheckFor(string _inputField, string _criteria){
			return ValidateThis (_inputField, _criteria);
		}

		public bool ValidateThis(string _inputField, string _criteria){
			switch (_criteria) {
				case Criteria.NOTNULL:
						if (string.IsNullOrEmpty (_inputField)){
							_return = false;
						} else {
							if (_inputField.TrimEnd (new Char[] { ' ' }) != "") {
								_return = true;
							} else {
								_return = false;
							}
						}
				break;
			case Criteria.EMAIL:
				if (string.IsNullOrEmpty (_inputField)) {
					_return = false;
				} else {
					_objReg = new Regex (@"^(?("""")("""".+?""""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
					_return = _objReg.IsMatch (_inputField);
				}
				break;
			case Criteria.MOBILE_NUMBER:
				if (string.IsNullOrEmpty (_inputField)) {
					_return = false;
				} else {
						// You may modify this _objReg to match your country mobile number pattern.
					_objReg = new Regex (@"^(0)?1[0-9]{8,9}$");
					_return = _objReg.IsMatch (_inputField);
				}
				break;
			case Criteria.INTEGERONLY:
				if (string.IsNullOrEmpty (_inputField)) {
					_return = false;
				} else {
					if (_inputField.TrimEnd (new Char[] { ' ' }) != "") {
						try {
							int.Parse (_inputField);
							_return = true;
						} catch (Exception) {
							_return = false;
						}
					} else {
						_return = false;
					}
				}
				break;
			case Criteria.MINIMUMCHAR6:
					if (_inputField.Length > 6) {
						_return = true;
					} else {
						_return = false;
					}
				break;
			case Criteria.FLOATONLY:
				if (string.IsNullOrEmpty (_inputField)) {
					_return = false;
				} else {
					if (_inputField.TrimEnd (new Char[] { ' ' }) != "") {
						try {
							var i = float.Parse (_inputField);
							_return = true;
						} catch (Exception) {
							_return = false;
						}
					} else {
						_return = false;
					}
				}
				break;
			case Criteria.NONE:
				_return = true;
				break;
			default:
					if (string.IsNullOrWhiteSpace (_inputField)) {
					_return = false;
				} else {
						try
						{
							_objReg = new Regex(_criteria);
							_return = _objReg.IsMatch(_inputField);
						}
						catch (Exception)
						{
							System.Diagnostics.Debug.WriteLine("Invalid RegEx Pattern");
							_return = false;
						}
				}
				break;

			}
			return _return;
		}
	}
}