   M S B A M L   `   `   `  ���� L  HTemplate.Frontend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:Template.Frontend.Models.ListItems"Template.Frontend.Models.ListItems  Y1clr-namespace:Template.Frontend.Models.ViewModels#Template.Frontend.Models.ViewModels  \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   BorderLightColor  BorderMediumColor  BorderDarkColor  PressedBorderLightColor  PressedBorderDarkColor  DisabledBorderLightColor  DisabledBorderDarkColor   DefaultBorderBrushLightBrush  DefaultBorderBrushDarkColor 	 HighlightColorBrush  �� Color 
 
Theme.Base  Theme.TitleBar  Theme.SideNav  Theme.Primary  Theme.Secondary  Theme.Foreground  Theme.Highlight  Theme.MenuBar  Brush.Clear �� Opacity  Brush.Theme.TitleBar  Brush.Theme.SideNav  Brush.Theme.Base  Brush.Theme.Primary  Brush.Theme.Secondary  Brush.Theme.Foreground  Brush.Theme.Highlight  Brush.Theme.MenuBar  FocusVisual �� Property �� Value J� SnapsToDevicePixels �� StrokeDashArray  Button.Static.Background  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border   Button.Pressed.Background ! Button.Pressed.Border " Button.Disabled.Background # Button.Disabled.Border $ Button.Disabled.Foreground % ControlTextBrushKey & HighlightBrushKey ' DefaultButtonStyle �� 
TargetType �� 
TargetType ��Name	 ��Name
 �� Triggers P� Property P� Value �� 
TargetName  ( Nav.Button.Static.Background ) Nav.Button.Static.Border #* Nav.Button.MouseOver.Background + Nav.Button.MouseOver.Border !, Nav.Button.Pressed.Background - Nav.Button.Pressed.Border ". Nav.Button.Disabled.Background / Nav.Button.Disabled.Border "0 Nav.Button.Disabled.Foreground 1 	NavButton !2 Menu.Button.Static.Background 3 Menu.Button.Static.Border $4  Menu.Button.MouseOver.Background  5 Menu.Button.MouseOver.Border "6 Menu.Button.Pressed.Background 7 Menu.Button.Pressed.Border #8 Menu.Button.Disabled.Background 9 Menu.Button.Disabled.Border #: Menu.Button.Disabled.Foreground ; 
MenuButton %< !Titlebar.Button.Static.Background != Titlebar.Button.Static.Border (> $Titlebar.Button.MouseOver.Background $?  Titlebar.Button.MouseOver.Border &@ "Titlebar.Button.Pressed.Background "A Titlebar.Button.Pressed.Border 'B #Titlebar.Button.Disabled.Background #C Titlebar.Button.Disabled.Border 'D #Titlebar.Button.Disabled.Foreground E 
ExitButton �� CornerRadius F parameterData �� DataType<    6Template.Frontend.Models.ViewModels.ParameterViewModel � ColumnDefinitions G parameterTemplateDataD   >Template.Frontend.Models.ViewModels.ParameterTemplateViewModel �� ItemTemplate �� ItemsSource H GroupBoxPanel � RowDefinitions I GroupBoxHeaderFullWidth �� Padding �� RelativeSource �� Mode �� AncestorType �� Path J ProjectDisplayOnly8   2Template.Frontend.Models.ListItems.ProjectListItem �� Triggers K EditableProject:   4Template.Frontend.Models.ViewModels.ProjectViewModel L EditableParameter � ToolTip M ExpandableParameterTemplate ��Name  N ParameterTemplateDisplayOnlyB   <Template.Frontend.Models.ListItems.ParameterTemplateListItem O TextBoxSingleBorder  P TextBoxSingleBorderWithLabel
 � Tag ��Name Q TextboxInlineSingleBorder-  'System.Windows.Input.KeyboardNavigation � 	Resources R Key �� TargetProperty  �� Target! �� ElementName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame" O� KeyTime# O� Value$   EasingFunction0  *System.Windows.Media.Animation.QuinticEase7  1System.Windows.Media.Animation.EasingFunctionBase%   
EasingMode& �� 
TargetName8	  2System.Windows.Media.Animation.EasingColorKeyFrame' �� KeyTime( �� Value) R� KeyTime* R� Value+ ��Name, J� RenderTransformOrigin- N� EnterActions S MoveInlineLabel. :� RoutedEvent/ ]� 
Conditions0 �� Property1 �� Value T ComboBoxToggleButton2 F�Name U ComboBoxTextBox3 �� 	ClickMode4 d� 	IsChecked5 �� Mode6 J� IsHitTestVisible7 �� SelectionBoxItem8 �� SelectionBoxItemTemplate9 ��Name: �� 
IsReadOnly; �� 
IsReadOnly< �� IsDropDownOpen= � AllowsTransparency> � ActualWidth? �� MaxDropDownHeight@ K� IsItemsHostA   DirectionalNavigationB P� 
SourceNameC �� Padding V CheckboxTextAlignLeftD �� 	Resources�� F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     >	listitems0clr-namespace:Template.Frontend.Models.ListItems  @
viewmodels1clr-namespace:Template.Frontend.Models.ViewModels  %�5  &	        &	      &	 &     &	 9     &	 L     &	 _     &	 r     &	 �     &	 �     &		 �     &	
 �     &	 �     &	 �     &	 �     &	 �     &	     &	     &	 .    &	 A    &	 \    7  &	 f    7  &	 p    7 
 &	 z    7  &	 �    7  &	 �    7  &	 �    7  &	 �    7  &	 �    &	 �    &	     &	 (    &	 =    &	  R    &	! g    &	" |    &	# �    &	$ �    &	% �    &	& �    &	' �    7  7  7  7 % 7 & 7  7  7   7 ! 7 " 7 # 7 $ &	( �    7  &	) �    7  &	* �    7  &	+ �    7  &	, �    7  &	-     7  &	.     &	/ !    &	0 6    &	1 K    7  7 ( 7 ) 7 % 7  7 * 7 + 7 , 7 - 7 . 7 / 7 0 &	2 f	    7  &	3 p	    7  &	4 z	    7  &	5 �	    7  &	6 �	    7  &	7 �	    7  &	8 �	    &	9 �	    &	: �	    &	; �	    7  7 2 7 3 7 % 7  7 4 7 5 7 6 7 7 7 8 7 9 7 : &	< �    &	= �    &	>     &	?     &	@ -    7  &	A 7    7  &	B A    &	C U    &	D j    &	E     7  7 < 7 = 7 % 7  7 > 7 ? 7 @ 7 A 7 B 7 C 7 D &	F �    &	G 8    7 F 7  &	H     7  7  7  7  &	I �    7  7  &	J h    &	K �    7 �&	L �    7  7 �7 �&	M �    7 L 7 ' &	N �    &	O n    7  7  &	P     7  7  7  7  &	Q N    7  7  7  7 S 7 S &	T �&    &	U !)    '�� ])    7 T 7 U '�� �.    &	V T0    ��	#FFCCCCCC����	#FF888888����	#FF444444����	#FF888888����	#FF444444����	#FFAAAAAA����	#FF888888����	#FFAAAAAA����	Black���� $
  Blue����	#FF444444����	Black����	Black����MediumPurple����
Purple����	White����#808080����	#FF3F3F3F���� $  White��$	 0.0Q��� 8    �� 8    �� 8    �� 8    �� 8    �� 8    �� 8    �� 8    �� .���  � �� �� .R��� $��2q�$
 true��#��� ��$��1��$	 1 2R��� $  	#FF3C7FB1���� $  	#FF2C628B���� $  	#FFBEE6FD���� $  	#FF3C7FB1���� $  	#FFC4E5F6���� $  	#FF2C628B���� $  DarkGray���� $  	#FFADB2B5���� $  	LightGray���� $  White���� $  	#FF838383���� " ��.���  �@�FocusVisualStyle8   ��  � ��8  ��  � ��8  ��  � ��8  ��  � ��$ 1q���  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � �� �� " ��.R��� $ border��#��z��#��z��#��z��$
 true��._��� $	 contentPresenter��$|�False��#��z��#��z��$
��True��# z #��z��
 P�  �@��IsDefaulted$
 true��. ��� $ border��8   � ��P�  �@J�IsMouseOver$
 true��. ��� $ border��8   � ���� $ border��8   � ��P�  � ��$
 true��. ��� $ border��8   � ���� $ border��8   � ��P�  � {�$ false��. ��� $ border��8 	  � ���� $ border��8 
  � ���� $ contentPresenter��8   � ���� 8    �� 8    �� 8    �� 8    �� 8    �� 8    �� $  DarkGray���� $  	#FFADB2B5���� $  	LightGray���� " ��.���  �@�FocusVisualStyle8   ��  � ��8  ��  � ��8  ��  � ��8  ��  � ��$ 40����  � ��$ 10q���  � ��$ 1q���  � ��$
 Left=���  � ��$ Center=���  � ��$ 1q���  � �� �� " ��.R��� $ border��#��z��#��z��#��z��$
 true��._��� $	 contentPresenter��$|�False��#��z��#��z��$
��True��# z #��z��
 P�  �@��IsDefaulted$
 true��. ��� $ border��8   � ��P�  �@J�IsMouseOver$
 true��. ��� $ border��8   � ���� $ border��8   � ��P�  � ��$
 true��. ��� $ border��8   � ���� $ border��8   � ��P�  � {�$ false��. ��� $ border��8 	  � ���� $ border��8 
  � ���� $ contentPresenter��8   � ���� 8    �� 8    �� 8    �� 8    �� 8    �� 8    �� $  DarkGray���� $  	#FFADB2B5���� $  	LightGray���� " ��.���  �@�FocusVisualStyle8   ��  � ��8  ��  � ��8  ��  � ��8  ��  � ��$ 40����  � ��$ 1q���  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � �� �� " ��.R��� $ border��#��z��#��z��#��z��$
 true��._��� $	 contentPresenter��$|�False��#��z��#��z��$
��True��# z #��z��
 P�  �@��IsDefaulted$
 true��. ��� $ border��8   � ��P�  �@J�IsMouseOver$
 true��. ��� $ border��8   � ���� $ border��8   � ��P�  � ��$
 true��. ��� $ border��8   � ���� $ border��8   � ��P�  � {�$ false��. ��� $ border��8 	  � ���� $ border��8 
  � ���� $ contentPresenter��8   � ���� $	  Red���� $	  Red���� $  PaleVioletRed���� $	  Red���� 8    �� 8    �� $  DarkGray���� $  	#FFADB2B5���� $  	LightGray���� " ��.���  �@�FocusVisualStyle8   ��  � ��8  ��  � ��8  ��  � ��8  ��  � ��$ 20����  � ��$ 20����  � ��$ 1q���  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � �� �� " ��.R��� $ border��$ 10��#��z��#��z��#��z��$
 true��._��� $	 contentPresenter��$|�False��#��z��#��z��$
��True��# z #��z��
 P�  �@��IsDefaulted$
 true��. ��� $ border��8   � ��P�  �@J�IsMouseOver$
 true��. ��� $ border��8   � ���� $ border��8   � ��P�  � ��$
 true��. ��� $ border��8   � ���� $ border��8   � ��P�  � {�$ false��. ��� $ border��8 	  � ���� $ border��8 
  � ���� $ contentPresenter��8   � ���� "   .R�� $��Stretch=� �� $��* ��� $��20��.+��� $��0������ *Symbol+�� $��-��$��1������ *DeleteCommand+�� "  8    �� *
Parameters+.R��� $ 5��8�� ._��  �� �� $��60��$��60��.+��� $��0��$��Stretch=����� *Name+�� $��1��$
��+Row������ *AddParameterCommand+�� " ��.���  � �� �� " ��.R��  �� $��30 ��� $��* �.+��� $��0��$��1q�8��  8�� ._��� 8�� .���� $��0q�$��Header��$
��True���� $��1��$��1,0,1,1q�8�� ._��� $	��0,0q��� .R��� 8��  $��0��$��20��$ 1,0,0,0q�$��1q�8�� ���� ����  �� $ FindAncestor=� GroupBox$ ActualWidth��� " ��.���  � �� �� "  .R��  �� �� .+��� $��0������ *Name+���� " �� P�  �@J�IsMouseOver$
 True��. ���  � �� �	#1FFF0000� $��1�� �� �� �� .+��� $��0��$��Italic$�$��10(����� *InputDirectory+�� $��1��$��Italic$�$��10(����� *SandboxDirectory+�� $��2��$��Italic$�$��10(����� *SqlDirectory+�� " ��.���  � ��$ Center=���  � �� �� "  .R��� $ 5��
�������$	��800��._�9� ���  �� $	��740 ��� $��40 �.+��� $��10,0,0,0q�$��0������ *Name+�� $��1��$��	10,0,10,0q�$��0q�8��  ���� *ShowMoreActionsCommand+����  �� *Self+.���� $9��3pack://application:,,,/Assets/Images/three-dots.png��.���  �� �� �� .+��� $��0��$��Italic$�$��10(����� *InputDirectory+�� $��1��$��Italic$�$��10(����� *SandboxDirectory+� $��2�� �� $��80 ��� .+��� $��0��$��Dependencies:��$��10(��� $��1��$��Italic$�$��10(�$
��Wrap=����� *Dependencies+�� " ��.���  � ��$ 5q���  � ��$ Center=���  � �� �� "   .R��� $ 5��8��  ._��  �� $��40 ��� $	��600 ��� $��0 ��� $��40 �.+��� $��0��$��	10,0,10,0q�$��0q�8��  �� *TypeImageTooltip+.���� $ 5��._��� ���� *TypeImageSource+� $��1�� �� �� .+��� $��0������ *Symbol+�� $��1��$��Italic$����� *Description+�� $��3��$��	10,0,10,0q�$��0q�8�� ���� *ShowMoreActionsCommand+����  �� *Self+.���� $9��3pack://application:,,,/Assets/Images/three-dots.png���� " ��.���  � ��$ Center=���  � ��$ 10q���  � �� �� "  .R��� $ 10��
�������$	��800��._�9� ���� *Name+.���  �� �� �� .+��� $��
Parameters��$��10q�$��0��$��2��.���� $ lbParams��$	��200��8��  ���� *
Parameters+���� " ��.���  � ��
 ������ $��2��$��10q� �� �� $��80 ��� $��40 �.+��� $��1��$��+ Parameter��8�� ���� *AddParameterCommand+�� " ��.���  � ��$ Center=���  � ��$ 10q���  � �� �� "  .R��� $ 10��
�������$	��300��._��� $��10,0,0,0q����� *Name+�� " ��.���  � ��$ 20����  � ��$	 150����  � ��$ 0,0,0,0q���  � ��8   ��  � ��8  ��  � ��
 �   ���  � ��$ 0 0 0 2q��� " ��.���  � ��$ 50����  � ��$ 0,0,0,0q���  � ��8   ��  � ��8  ��  � ��
 �   ���  � ��$ 0 0 0 2q���  � �� �� " ��.R��  �� $��20 ��� $��25 �.+��� $��0��#��z 8�� $��0,0,0,-5q��� $ border��$��1��#��z��#��z��#��z��$
 True��#��z��$��10,0,0,0q�#{�z{�._��� $ PART_ContentHost��$|�false��$��Hidden=�$��Hidden=� P�  � {�$ False��. ���  � ��
 �������  � ��
 �����P�  � {�$
 True��. ���  � ��8  ��  � ��
 �   ��� " ��.���  � ��$ 35����  � ��$	 150����  � ��$ 0,0,0,0q���  � ��8   ��  � ��8  ��  � ��8  ��  � ��$ 0 0 0 2q���  �@ TabNavigation$
 None=���  � ��$
 Left=���  �@�FocusVisualStyle Z� ��  �@J�	AllowDrop$
 true����  �@��PanningMode$ VerticalFirst=���  �@��IsFlicksEnabled$ False����  � �� �� " �� ���� MoveInlineLabelR .��U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�  �� $! 	textBlock��.\�  $" 0:0:0.6��$# -6.667Q�$   $% 	EaseInOut=�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�  �� $! 	textBlock��.\�  $" 0:0:0.6��$# -18.733Q�$   $% 	EaseInOut=��� $6 0(TextElement.Foreground).(SolidColorBrush.Color)�$& 	textBlock��.g�	  $' 0:0:0.6��$( 	#FF0285BA��T� $ (TextElement.FontWeight)�$& 	textBlock��..�i� $) 0:0:0.3��* #�Bold"�.R�� .+��� $ border��$��1��#��z��#��z��#��z��$
 True��._��� $ PART_ContentHost��$|�false��$��0,10,0,0q�$��Hidden=�$��Hidden=��� $+ 	textBlock��#��z $��Center=�$��4,0,0,-5q�
�������$, 0.5,0.5&�z�V� .~��� �� �� T� 
 P�  � {�$ false��. ��� $ border�� �@J�Opacity$
 0.56Q�P�  �@J�IsMouseOver$
 true��. ��� $ border�� � �� �	#FF7EB4EAP�  �@J�	IsFocused$
 True��. ��� $ border�� � ��
 � ���P�  �@J�IsKeyboardFocused$
 true��. ��� $ border�� �� *BorderBrush+ � ���� $ border�� � ��
 � ���- �� 8�� :� $. TextBox.TextChanged��.[��� 8��  ]� / �� +0 �@��#IsInactiveSelectionHighlightEnabled$
1 true���� 0 �@��IsSelectionActive$1 false��./���  �@��SelectionBrush# � /��� " d�.R��  �� �� $��20 �.+��� $ Border��$��2��$ 0�����	#FF3F3F3F���	#FF97A0A5$��1q��� $��0��$ 0��$��1q����	#FF3F3F3F���	#FF97A0A5$��0,0,1,0q�F� $2 Arrow��$��1��
�������$��Center=�$��Center=�=����        �    �� � 	= ��[ � z �� � z     � 	=  	= 	
 P�  �@J�IsMouseOver$
 true��. ��� $ Border�� � �� �#808080P�  �@d�	IsChecked$
 trueY�. ��� $ Border�� � �� �#E0E0E0P�  � {�$ False��. ��� $ Border�� � �� �#EEEEEE�� $ Border�� � �� �#AAAAAA��  � �� �#888888�� $ Arrow�� � �� �#888888�� " ��.R��� $ PART_ContentHost��$|�False��#��z���� " ��.���  �@J�SnapsToDevicePixels$
 true����  �@�OverridesDefaultStyle$
 true����  � ��$
 Auto=���  � ��$
 Auto=���  � ��$
 true����  � ��$	 120����  � ��$ 20����  � ��
 �������  � �� �� " ��.R�� .+�d� $��ToggleButton��8��  $��2��$|�false��$3 Press=�4 �� $ IsDropDownOpen�$5 TwoWay=� �� *TemplatedParent+�� $��ContentSite��$6 False��#��z7 #��z8 #��z��$��3,3,23,3q�$��Center=�$
��Left=��� $9 PART_EditableTextBox��8�� $
��Left=�$��Center=�$��3,3,23,3q�$
|�True�����	#FF3F3F3F
�������$y�Hidden=�#; z: ��Z� � $��Popup��$��Bottom=�#��z< $
= True��$|�False��$��Slide=�.��� $��DropDown��$
 True��#��z> #��z? .+��� $ DropDownBorder�����	#FF3F3F3F$��1q����#888888�� $��4,6,4,6q�$
 True��.���� $
@ True��$A 	Contained=�
 P�  �@��HasItems$ false��. ��� $ DropDownBorder�� � ��$ 95��P�  � {�$ false��. ���  � �� �#888888P�  �@��
IsGrouping$
 true��. ���  � ��$ false��P� $B Popup�� �@�AllowsTransparency$
 true��. ��� $ DropDownBorder�� �@��CornerRadius$ 0���� $ DropDownBorder�� � ��$ 0,2,0,0q�P�  �@��
IsEditable$
 true��. ���  � ��$ false���� $ PART_EditableTextBox�� � y�$ Visible=��� $ ContentSite�� � y�$ Hidden=� �� " ��.���  �@J�SnapsToDevicePixels$
 true����  � ��
 �������  �@�OverridesDefaultStyle$
 true����  � �� �� " ��.R��� $��Border��$C 2q�$
 true��._��� 
 P�  �@��IsHighlighted$
 true��. ��� $ Border�� � �� �	#FF4F4F4FP�  � {�$ false��. ���  � �� �#888888�� " ��D ���� 'F�       " F�.���  � ��$ LeftToRight=��� '��       " ��.���  � ��$ LeftToRight=�.���  � ��$ RightToLeft=�