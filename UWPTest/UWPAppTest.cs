using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Threading;
using System.Windows.Automation;

namespace UWPTest
{
    [TestClass]
    public class UWPAppTest
    {
        [TestMethod]
        public void RunUWPApp()
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = @"C:\Program Files (x86)\Windows Kits\10\App Certification Kit\microsoft.windows.softwarelogo.appxlauncher.exe";
            psi.Arguments = "e6fb2184-4022-4438-b777-b6a78e17afaa_85n9n080kadme!App";
            // add !App to package family name taken from manifest

            using (Process process = Process.Start(psi))
            {
                Thread.Sleep(10000);

                var root = AutomationElement.RootElement;
                var app = root.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, "UWPApp"));

                
                // TextBox

                var txtTest = app.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, "txtTest"));
                txtTest.SetFocus();
                ((ValuePattern)txtTest.GetCurrentPattern(ValuePattern.Pattern)).SetValue("La-la-la");


                // ComboBox

                var comboClients = app.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, "cbTest"));
                comboClients.SetFocus();
                ((ExpandCollapsePattern)comboClients.GetCurrentPattern(ExpandCollapsePatternIdentifiers.Pattern)).Expand();
                
                Thread.Sleep(500);

                var listItem = comboClients.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.NameProperty, "Test Item 2"));
                ((SelectionItemPattern)listItem.GetCurrentPattern(SelectionItemPattern.Pattern)).Select();

                ((ExpandCollapsePattern)comboClients.GetCurrentPattern(ExpandCollapsePatternIdentifiers.Pattern)).Collapse();

                Thread.Sleep(500);

                // CheckBox

                var chkTest = app.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, "chkTest"));
                chkTest.SetFocus();
                (chkTest.GetCurrentPattern(TogglePattern.Pattern) as TogglePattern).Toggle();

                Thread.Sleep(500);

                // DatePicker

                var pickerFrom = app.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, "pickerFrom"));

                var pickerButton = pickerFrom.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, "FlyoutButton"));
                (pickerButton.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern).Invoke();

                var monthLoopingSelector = root.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, "MonthLoopingSelector"));
                var month = monthLoopingSelector.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.NameProperty, "November"));
                ((SelectionItemPattern)month.GetCurrentPattern(SelectionItemPattern.Pattern)).Select();

                var dayLoopingSelector = root.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, "DayLoopingSelector"));
                var day = dayLoopingSelector.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.NameProperty, "30"));
                ((SelectionItemPattern)day.GetCurrentPattern(SelectionItemPattern.Pattern)).Select();

                var yearLoopingSelector = root.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, "YearLoopingSelector"));
                var year = yearLoopingSelector.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.NameProperty, "2020"));
                ((SelectionItemPattern)year.GetCurrentPattern(SelectionItemPattern.Pattern)).Select();

                // Button

                var acceptButton = root.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, "AcceptButton"));
                (acceptButton.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern).Invoke();

                process.Close();
            }

            Assert.IsTrue(true);
        }
    }
}
