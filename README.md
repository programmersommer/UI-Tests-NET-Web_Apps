For Selenium tests you should download driver for you browser and place it in to application folder.
Currently Chrome driver is used


For WPF/UWP tests you should add references to UIAutomationClient and UIAutomationTypes libraries.

In XAML code of you tested application you can set AutomationId property by setting value of AutomationProperties.AutomationId attribute.

With help of utility called **inspect.exe** you will be able to find automation id and some other information.

This utility is located in "Windows Kits" folder. For example on my machine full path is:   
C:\Program Files (x86)\Windows Kits\10\bin\10.0.16299.0\x86

![inspect.exe](https://github.com/programmersommer/UI-Tests-NET-Web_Apps/blob/master/inspect.png)

With this application you can get not only id or name, but also some more information. For example, patterns that control supports.

In case if you want to get AutomationId of some element that would be hidden after click, you can just hover cursor over buttons:
"Navigate to Parent", "Navigate to First Child" etc.
