You should add references to UIAutomationClient and UIAutomationTypes libraries.

In XAML code you can set AutomationId property by setting value of AutomationProperties.AutomationId attribute.

With help of utility called **inspect.exe** you will be able to find automation id and some other information.

This utility is located in "Windows Kits" folder. For example on my machine full path is:   
C:\Program Files (x86)\Windows Kits\10\bin\10.0.16299.0\x86

![inspect.exe](https://github.com/programmersommer/AutomationUI/blob/master/inspect.png)

With this application you can get not only id or name, but also some more information. For example, patterns that control supports.



