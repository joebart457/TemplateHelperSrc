   M S B A M L   `   `   `  ���� L  HTemplate.Frontend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Template.FrontendTemplate.Frontend  "    Template.Frontend.MainWindow   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:Template.Frontend       � Title$  
MainWindow��$	��800��$
��1400�� � AllowsTransparency$
 True�� � WindowStyle$
 None=�����  �� Opacity$	 0.5Q� �� Color$ White�� � 	Resources  �� Source�� $ Styles/Common.xaml?�%    .���  � RowDefinitions �� $��40 ���  � ColumnDefinitions �� $	��160 ��� .+�� -   	 �Name$	 TitleBar��$��0��$��1��$��1������    Theme.TitleBar# [  $	 0.9Q� �� �� $��40 ��� $��40 ��� $��40 �.+��� -   
 ��Name$ 
 Button_MinimizeApplication��$��1��$��	10,0,10,0q�$��0q�#��[" �.���� $7��1pack://application:,,,/Assets/Images/minimize.png���� -   $ 
 Button_MaximizeApplication��$��2��$��	10,0,10,0q�$��0q�#��[" �.���� $7��1pack://application:,,,/Assets/Images/maximize.png���� -   $
 Button_CloseApplication��$��3��$��10q�$��0q�#��[" �.���� $0��*pack://application:,,,/Assets/Images/X.png��� -   $	 SideBar��$��0��$��0��$��2��$��1������   Theme.SideNav# [ .+��� .+��  �� $��40 ��� -   $)
 #Button_NavigateToParameterTemplates��$��Parameter Templates��  	NavButton#��[ �� -   $
 Button_NavigateToProjects��$��Projects��#��[ �� -   $!
 Button_NavigateToRunSession��$	��Run��#��[ �� -	   $!
 Button_NavigateToCodeEditor��$��Code Sandbox��#��[ �� -
   $
 Button_NavigateToHelp��$
��Help��#��[ � -   $	 MainContentArea��$��1��$��1������   
Theme.Base# [ $	 0.3Q�.+� � -     �Name$ Frame_MainContent��  � Source$ Pages\MainScreen.xaml?�  � NavigationUIVisibility$ Hidden=�