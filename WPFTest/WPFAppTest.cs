using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Automation;

namespace WPFTest
{
    [TestClass]
    public class WPFAppTest
    {
        [TestMethod]
        public void RunWPFApp()
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = @"D:\BestPractices\UI_Tests_NET_Apps\WPFCoreApp\bin\Debug\WPFCoreApp.exe";
            psi.WorkingDirectory = @"D:\BestPractices\UI_Tests_NET_Apps\WPFCoreApp\bin\Debug\";

            using (Process process = Process.Start(psi))
            {

                int timeWait = 1000;
                int maxTime = 10000;
                int runningTime = 0;
                while (process.MainWindowHandle.Equals(IntPtr.Zero))
                {
                    if (runningTime > maxTime)
                        throw new Exception("Application is not found");

                    Thread.Sleep(timeWait);
                    runningTime += timeWait;

                    process.Refresh();
                }

                var app = AutomationElement.FromHandle(process.MainWindowHandle);


                // TextBox

                var txtTest = app.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, "txtTest"));
                txtTest.SetFocus();
                ((ValuePattern)txtTest.GetCurrentPattern(ValuePattern.Pattern)).SetValue("La-la-la");


                // CheckBox

                var chkTest = app.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, "chkTest"));
                chkTest.SetFocus();
                (chkTest.GetCurrentPattern(TogglePattern.Pattern) as TogglePattern).Toggle();


                // ComboBox

                var cbTest = app.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, "cbTest"));
                cbTest.SetFocus();
                ((ExpandCollapsePattern)cbTest.GetCurrentPattern(ExpandCollapsePatternIdentifiers.Pattern)).Expand();

                Thread.Sleep(500);

                var listItem = cbTest.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.NameProperty, "Test Item 2"));
                ((SelectionItemPattern)listItem.GetCurrentPattern(SelectionItemPattern.Pattern)).Select();
                ((ExpandCollapsePattern)cbTest.GetCurrentPattern(ExpandCollapsePatternIdentifiers.Pattern)).Collapse();


                // ComboBox with binding

                var cbCountry = app.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, "cbCountry"));
                cbCountry.SetFocus();
                ((ExpandCollapsePattern)cbCountry.GetCurrentPattern(ExpandCollapsePatternIdentifiers.Pattern)).Expand();

                Thread.Sleep(500);

                var listItem2 = cbCountry.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.NameProperty, "Belarus"));

                var controlViewWalker = TreeWalker.ControlViewWalker;
                listItem2 = controlViewWalker.GetParent(listItem2);

                ((SelectionItemPattern)listItem2.GetCurrentPattern(SelectionItemPattern.Pattern)).Select();
                ((ExpandCollapsePattern)cbCountry.GetCurrentPattern(ExpandCollapsePatternIdentifiers.Pattern)).Collapse();


                // DatePicker

                var pickerFrom = app.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, "pickerFrom"));
                pickerFrom.SetFocus();
                ((ExpandCollapsePattern)pickerFrom.GetCurrentPattern(ExpandCollapsePatternIdentifiers.Pattern)).Expand();

                // select date in current month
                var pickerFromItem = pickerFrom.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, "Friday, July 17, 2020"));
                (pickerFromItem.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern).Invoke();
                ((ExpandCollapsePattern)pickerFrom.GetCurrentPattern(ExpandCollapsePatternIdentifiers.Pattern)).Collapse();

                process.Kill();
            }

            Assert.IsTrue(true);
        }
    }
}
