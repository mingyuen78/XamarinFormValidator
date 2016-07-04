// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace ValidationForm.iOS
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        UIKit.UIButton Button { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnSubmit { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtAge { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtAlias { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtEmail { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtEmployeeCode { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtFullName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtMobileNumber { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnSubmit != null) {
                btnSubmit.Dispose ();
                btnSubmit = null;
            }

            if (txtAge != null) {
                txtAge.Dispose ();
                txtAge = null;
            }

            if (txtAlias != null) {
                txtAlias.Dispose ();
                txtAlias = null;
            }

            if (txtEmail != null) {
                txtEmail.Dispose ();
                txtEmail = null;
            }

            if (txtEmployeeCode != null) {
                txtEmployeeCode.Dispose ();
                txtEmployeeCode = null;
            }

            if (txtFullName != null) {
                txtFullName.Dispose ();
                txtFullName = null;
            }

            if (txtMobileNumber != null) {
                txtMobileNumber.Dispose ();
                txtMobileNumber = null;
            }
        }
    }
}