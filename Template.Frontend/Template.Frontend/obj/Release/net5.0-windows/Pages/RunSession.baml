   M S B A M L   `   `   `  ���� L  HTemplate.Frontend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Template.Frontend.PagesTemplate.Frontend.Pages  (    "Template.Frontend.Pages.RunSession   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     7local%clr-namespace:Template.Frontend.Pages       N� Title$  
RunSession�� � 	Resources  �� Source�� $ ../Styles/Common.xaml?�%    .��� .+�� -    �Name$ MainContentArea��$��1��$��1��$��1������    
Theme.Base �� Color# [   �� Opacity$	 0.3Q� � RowDefinitions �� �� �� �� �� �� �� ��  � ColumnDefinitions �� �� �� �� �� �� �� �� �� �� �� .+��� $�� ��  GroupBoxPanel#��[   GroupBoxHeaderFullWidth � DataContext# [ $��7��$��0��$��
44,25,6,47q�$��8��.��� ���� $ White��$	 0.1Q� �� $��20 ���  �� �� �� �� .+�� $��0��$��4������ $ 	#FF3F3F3F��$
 01.0Q� ��  �� �� �� $��60 �.+��� -   	 ��Name$	 ComboBox_ProjectsSelect��
 �� 
IsEditable$

 True��$��0��$��0���� -    ��Name$ Button_AddFilledParameter��$��2�����	#FF3F3F3F
����������	#FF3F3F3F$
��+Row��&   System.Windows.Controls.DataGrid  -     Name$# DataGrid_FilledParametersEdit��$��1��$��4��   AutoGenerateColumns$ False��   CanUserAddRows$ False��   CanUserDeleteRows$ False��   
IsReadOnly$ False��   HeadersVisibility$ Column=�$��Stretch=�   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ *    GridLinesVisibility$ 
Horizontal=����� $ White��$	 0.3Q�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width$
 Auto    Header$ Template��   
IsReadOnly$
 True��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *TemplateName+  $
 Auto $ Symbol�� �� *Symbol+   	CellStyle ��  �� 
TargetType*  $System.Windows.Controls.DataGridCell"  .���  �� Property �@�ToolTip �� Value �� *Description+  $
 Auto $  Symbol Type��$
 True�� �� *Type+  $	 200 $ Value�� �� *Value+�� -    ��Name$ GroupBox_RunSessionEdit��$��7��$��Settings��$��4��$��102,25,44,47q�$��8��${�False��#��[ #��[ .��� ���� # [  $	 0.9Q� �� �� ��  �� �� �� �� .+�� $��0��$��4�� �� $
��250* ��� $
��249* � �� $��10 ��� �� �� �� $��10 �.+��� -    ��Name$ TextBox_OutputDirectory��$��1��$��2��$
��Left=�$��10,0,0,0q�$�� �� �� TextWrapping$
 Wrap=�$��Center=�$	��194��
  � Tag$  Output Directory��   TextBoxSingleBorderWithLabel#���  �� -   $" Button_BrowseOutputDirectory��$��1��$��1��$��60��$��20��$��
72,23,0,22q�$
��Left=�  DefaultButtonStyle#��[ $��Browse���� -   ! ��Name$! CheckBox_RunForSandbox��$��2��$��Run In Sandbox��  Brush.Theme.Foreground#��[ $
��Left=�$��
10,10,0,10q��� -	   $! CheckBox_AllowOverwrite��$��2��$��Allow overwrite��#��[ $
��Left=�$��
10,30,0,10q�� $��3��$��2�� �� $��80 ��� �� .+��� -
   $ Button_RunSession��$��0��$��0��$��60��$��20��$	��Run��#��[ $
��Left=�$��
10,17,0,17q��� -   " ��Name$" Label_TaskProgress��$��0��$��1��$��3��$
��Left=�$
��Left=�$
��Idle��$��0,5,0,0q�$	��200��$��30��