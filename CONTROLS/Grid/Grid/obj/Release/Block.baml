   M S B A M L   `   `   `  ���� @  <Label, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null,"clr-namespace:Label;assembly=LabelLabel  C ?ComboBox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:ComboBox;assembly=ComboBoxComboBox J FStatusIndicator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullJ6clr-namespace:StatusIndicator;assembly=StatusIndicatorStatusIndicator ? ;Grid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:GridGrid    Grid.tempBlock   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     4Label"clr-namespace:Label;assembly=Label     =ComboBox(clr-namespace:ComboBox;assembly=ComboBox     RStatusIndicator6clr-namespace:StatusIndicator;assembly=StatusIndicator     *UserControlclr-namespace:Grid     -     
Grid.Block   Name$  blockControl��  
Grid.Block   SizeChanged$ blockControl_SizeChanged��   	MouseDown$ blockControl_MouseDown��   	MouseMove$ blockControl_MouseMove�� � 	Resources    ComboBoxToggleButton �� 
TargetType � ColumnDefinitions ��Name �� CornerRadius  BackgroundColor  BorderColor	 F�Name  ComboBoxTextBox
 �� 
TargetType �� Property �� Value �� 	ClickMode d� 	IsChecked �� Path �� Mode �� RelativeSource J� IsHitTestVisible �� SelectionBoxItem �� SelectionBoxItemTemplate ��Name �� 
IsReadOnly �� 
IsReadOnly �� IsDropDownOpen � AllowsTransparency J� SnapsToDevicePixels � ActualWidth �� MaxDropDownHeight K� IsItemsHost-  'System.Windows.Input.KeyboardNavigation   DirectionalNavigation �� Triggers  P� Property! P� Value" �� 
TargetName# P� 
SourceName$ �� Triggers% �� Padding& �� Color'  !System.Windows.VisualStateManager'   VisualStateGroups%  System.Windows.VisualStateGroup(   States   System.Windows.VisualState)   
Storyboard* �� 
TargetName+ �� TargetProperty8  2System.Windows.Media.Animation.EasingColorKeyFrame, �� KeyTime  DisabledControlLightColor- �� Value  DisabledControlDarkColor. ��Name  CheckBoxFocusVisual/ �� 
Background0 �� Bullet1 @� Center2 @� RadiusX3 @� RadiusY  PressedBrush  PressedBorderBrush 	 DisabledBackgroundBrush 
 DisabledBorderBrush  DisabledForegroundBrush4 �� StrokeDashArray  BackgroundBrush  BorderBrush5 �� 
StartPoint6 �� EndPoint7 � Color8 � Offset��%8  &	        &	     '�� P    7   7  '�� �    '�� �    '�� �
    &	 �    &	 ^    &	 o    &	 �    &	 �    &	 �    &	 �    &	 �    &		 �    &	
 �    &	 �    �� " d�.R��  �� �� $��50 �.+��� $ Border��$��2��$ 5��#���  #���  $��1q��� $��0��$ 4��$��1q�#���  #���  $��0,0,1,0q�F� $	 Arrow��$��1��
�������$��Center=�$��Center=�=����        �    �� � 	= ��[ � z �� � z     � 	=  	= 	�� " ��.R��� $ PART_ContentHost��|�.  #��z���� "
 ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � ��$
 Auto=���  � ��$
 Auto=���  � �� . ��  � ��$	 120����  � ��$ 20����  � ��
 �������  � �� �� " ��.R�� .+�d� $��ToggleButton��8��  $��2��|�.  $ Press=� �� $ IsDropDownOpen�$ TwoWay=� �� *TemplatedParent+�� $��ContentSite�� .  #��z #��z #��z��$��3,3,23,3q�$��Center=�$
��Left=��� $ PART_EditableTextBox��8�� $
��Left=�$��Center=�$��3,3,23,3q�|�. ���	#FF3F3F3F
��� � �$y�Hidden=�# z ��Z� � $��Popup��$��Bottom=�#��z  . |�.  $��Slide=�.��� $��DropDown�� . #��z #��z .+��� $ DropDownBorder��#���  $ 5��$��1q�#���  �� $��4,6,4,6q� . .����  . $ 	Contained=� P�   �@��HasItems! .  . ��� $" DropDownBorder�� � ��$ 95��P�   � {�! .  . ���  � �� �#888888P�   �@��
IsGrouping! . . ���  � �� .  P� $# Popup��  �@�AllowsTransparency! . . ��� $" DropDownBorder�� �@��CornerRadius$ 0���� $" DropDownBorder�� � ��$ 0,2,0,0q�P�   �@��
IsEditable! . . ���  � �� .  �� $" PART_EditableTextBox�� � y�$ Visible=��� $" ContentSite�� � y�$ Hidden=�$ �� "
 ��.���  �@J�SnapsToDevicePixels . ��  � ��
 �������  �@�OverridesDefaultStyle . ��  � �� �� " ��.R��� $��Border��$% 2q� . ._���  P�   �@��IsHighlighted! . . ��� $" Border��# �   � ��P�   � {�! .  . ���  � �� �#888888�� "
 ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  �@ TabNavigation$
 None=���  �@�FocusVisualStyle Z� ��  � ��$	 120����  � ��$ 20����  �@J�	AllowDrop . ��  � �� �� " ��.R��� $��Border��$ 4��$% 2q�$��1q����� #& �  ���� #& �  '   CommonStates��.(   
Normal��  Disabled��.) �� .���� $* Border��$E+ ?(Panel.Background).                     (SolidColorBrush.Color)�.g�  $, 0��#- �    ReadOnly��.) �� .���� $* Border��$E+ ?(Panel.Background).                     (SolidColorBrush.Color)�.g�  $, 0��#- �    	MouseOver��._��� $. PART_ContentHost��$��0q��� "
 ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  �@�FocusVisualStyle# �  ��  � �� �� " ��.R��� 
/ ���� 0 �� $ Border��$��14��$��14��$ 7��#���  $��2q�#���  ._�F� $	 	CheckMark��$��7��$��7�� .  #���  ��@� $1 3.5,3.5&�$	2 3.5Q�$	3 3.5Q�._��� $��4,0,0,0q�$��Center=�$
��Left=���.  P�   �@d�	IsChecked$! falseY�. ��� $" 	CheckMark�� � y�$ 	Collapsed=�P� ! Z�   �@d�	IsChecked. ��� $" 	CheckMark�� � �� ��    ��j ���j     	P�   �@J�IsMouseOver! . . ��� $" Border�� � �� �#DDDDDDP�   � ��! . . ��� $" Border��# �   � ���� $" Border��# �   � ��P�   � {�! .  . ��� $" Border��# � 	  � ���� $" Border��# � 
  � ���� # �   � ���� .���  � �� �� .R��� ._��� $��15,0,0,0q�$��1�����	#60000000$	4 1 2R���#4C4C33����#999966����#222����LightSteelBlue����	#FFE8EDF9����	#FFC5CBF9���� $
& #888���� $
& #EEE���� $
& #AAA���� $	5 0,0&�$	6 0,1&���� � $
7 #BBB��$	8 0.0Q�� $
7 #EEE��$	8 0.1Q�� $
7 #EEE��$	8 0.9Q�� $
7 #FFF��$	8 1.0Q�.���� -   $ borderOuter��#���  #���  $��1q�$ 10��._�� -   9 �Name$9 	gridOuter��.+��� -   : ��Name$: labelSeparator��$�� ��$
��Left=�$��	10,46,0,0q�$	��Top=�$	��276��#���  $��1��; J� OpacityMask; �� $	6 1,1&�$	5 0,1&�.��� $7 Black��$	8 0.8Q�� $8 1Q�� $7 Black��$	8 0.2Q�� ,  &StatusIndicator.StatusIndicatorControl  -   <  Name$< statusIndicator��$
��Left=�$��2,19,0,0q�$	��Top=�$��20��$��20���� $��
Block_Type��$
��Left=�$��	25,16,0,0q�$	��Top=����	#FFBFBFBF	   Label.ConnectionStatus	  -   = 	 Name$= connectionStatusTop��$
��Left=�$��10,4,0,0q�$	��Top=�$	��276��$��10��	  -   $= connectionStatusBot��$
��Left=�$��
10,283,0,0q�$	��Top=�$	��276��$��10��