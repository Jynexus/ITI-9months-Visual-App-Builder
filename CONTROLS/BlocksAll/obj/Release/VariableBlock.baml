   M S B A M L   `   `   `  ���� J  FResourceClasses, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null|Oclr-namespace:VisualApplicationBuilder.ResourceClasses;assembly=ResourceClasses(VisualApplicationBuilder.ResourceClasses   	BlocksAll3   -VisualApplicationBuilder.Block.DataTypesBlock   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     gUserControlOclr-namespace:VisualApplicationBuilder.ResourceClasses;assembly=ResourceClasses     -   8   2VisualApplicationBuilder.ResourceClasses.BlockBase   Name$  blockControl��$	��125��$	��250�� � 	Resources    ComboBoxToggleButton �� 
TargetType � ColumnDefinitions ��Name �� CornerRadius  BorderBrush  	BlueBrush  BackgroundBrush F�Name  ComboBoxTextBox �� 
TargetType �� Property	 �� Value
 d�Name �� 	ClickMode d� 	IsChecked �� Mode �� RelativeSource ��Name J� IsHitTestVisible �� SelectionBoxItem �� SelectionBoxItemTemplate ��Name �� 
IsReadOnly �� 
IsReadOnly �Name �� IsDropDownOpen � AllowsTransparency �Name J� SnapsToDevicePixels � ActualWidth �� MaxDropDownHeight K� IsItemsHost-  'System.Windows.Input.KeyboardNavigation   DirectionalNavigation �� Triggers  P� Property! P� Value" �� 
TargetName# P� 
SourceName$ �� Padding  CheckBoxFocusVisual% �� 
Background& �� Bullet' @� Center( @� RadiusX) @� RadiusY  PressedBrush  PressedBorderBrush  DisabledBackgroundBrush 	 DisabledBorderBrush 
 DisabledForegroundBrush* �� StrokeDashArray  DisabledControlLightColor  DisabledControlDarkColor+ �� Color��%�  &	        &	     '�� L    7   7  '�� �    '�� �    &	     &	 n    &	 |    &	 �    &	 �    &	 �    &	 �    &	
 �    &	 �    &		 �    �� " d�.R��  �� �� $��40 �.+��� $ Border��$��2��$ 3��#���  #���  $��1q��� $��0��$ 3��$��1q�#���  #���  $��0,0,1,0q�F� $ Arrow��$��1��#���  $��Center=�$��Center=�=����        �    �� � 	= ��[ � z �� � z     � 	=  	= 	�� " ��.R��� $ PART_ContentHost��|�.  #��z���� " ��.���  �@J�SnapsToDevicePixels	 . ��  �@�OverridesDefaultStyle	 . ��  � ��$
	 Auto=���  � ��$
	 Auto=���  � ��	 . ��  � ��$		 120����  � ��$	 20����  � ��
	 �������  � ��	 �� " ��.R�� .+�d� $
 ToggleButton��8��  $��2��|�.  $ Press=� �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+�� $ ContentSite�� .  #��z #��z #��z��$��3,3,23,3q�$��Center=�$
��Left=��� $ PART_EditableTextBox��8�� $
��Left=�$��Center=�$��3,3,23,3q�|�. ���	#FF3F3F3F
��� � �$y�Hidden=�# z ��Z� � $ Popup��$��Bottom=�#��z  . |�.  $��Slide=�.��� $ DropDown�� . #��z #��z .+��� $ DropDownBorder��#���  $ 5��$��1q�#���  �� $��4,6,4,6q� . .����  . $ 	Contained=� P�   �@��HasItems! .  . ��� $" DropDownBorder�� � ��$	 95��P�   � {�! .  . ���  � ��	 �#888888P�   �@��
IsGrouping! . . ���  � ��	 .  P� $# Popup��  �@�AllowsTransparency! . . ��� $" DropDownBorder�� �@��CornerRadius$	 0���� $" DropDownBorder�� � ��$	 0,2,0,0q�P�   �@��
IsEditable! . . ���  � ��	 .  �� $" PART_EditableTextBox�� � y�$	 Visible=��� $" ContentSite�� � y�$	 Hidden=��� " ��.���  �@J�SnapsToDevicePixels	 . ��  � ��
	 �������  �@�OverridesDefaultStyle	 . ��  � ��	 �� " ��.R��� $ Border��$$ 2q� . ._���  P�   �@��IsHighlighted! . . ��� $" Border��#	 �   � ��P�   � {�! .  . ��� #	 �   � ���� " ��.���  �@J�SnapsToDevicePixels	 . ��  �@�OverridesDefaultStyle	 . ��  �@�FocusVisualStyle#	 �  ��  � ��	 �� " ��.R��� 
% ���� & �� $ Border��$��14��$��14��$ 7��#���  $��2q�#���  ._�F� $ 	CheckMark��$��7��$��7�� .  #���  ��@� $' 3.5,3.5&�$	( 3.5Q�$	) 3.5Q�._��� $��4,0,0,0q�$��Center=�$
��Left=���.  P�   �@d�	IsChecked$! falseY�. ��� $" 	CheckMark�� � y�$	 	Collapsed=�P� ! Z�   �@d�	IsChecked. ��� $" 	CheckMark�� � ��	 ��    ��j ���j     	P�   �@J�IsMouseOver! . . ��� $" Border�� � ��	 �#DDDDDDP�   � ��! . . ��� $" Border��#	 �   � ���� $" Border��#	 �   � ��P�   � {�! .  . ��� $" Border��#	 �   � ���� $" Border��#	 � 	  � ���� #	 � 
  � ���� .���  � ��	 �� .R��� ._��� $��15,0,0,0q�$��1�����	#60000000$	* 1 2R���#222����LightSteelBlue����	#FF007ACC����#EEE����	#FFE8EDF9����	#FFC5CBF9���� $
+ #888���� $
+ #EEE���� $
+ #AAA��.���� -   $ borderOuter��#���  #���  $��1q�$ 10��$��0,0,1,-1q�._��� -   , ��Name$, stackPanelOuter��$��0q�.+�� $��30��.+��� -   - ��Name$- labelBlockName��$��	Data type��$
��Left=�$��26,1,0,0q�$	��Top=����	#FFBFBFBF$��26��$��61��A� -   . A�Name$. statusIndicator��$
��Left=�$��17��$��17��$��10,6,0,0q����	#FF007ACC$	��Top=��� -   / ��Name$/ buttonRemoveBlock��$��0,2,8,0q�$	��Top=�$��25��$��25��
���""��$��Right=���Z� ��Z� 0 J� OpacityMask0 L� 1 �� RelativeTransform1 V� .~��� 2 �� CenterY$	2 0.5Q�3 �� CenterX$	3 0.5Q�4 �� ScaleX$	4 0.8Q�5 �� ScaleY$	5 0.8Q��� 6 �� CenterY$	6 0.5Q�7 �� CenterX$	7 0.5Q��� 8 �� CenterY$	8 0.5Q�9 �� CenterX$	9 0.5Q�T� : L� Drawing: I� .��� 
; � Pen; >� < >� 	Thickness$< 5Q�= >� Brush
= �   �> � Geometry> @� $( 20Q�$) 20Q�� +> ��@0��@0�����j ��j ���j @0���@0����j 	; >� $< 5Q�
= �   ��� -   $- labelSeparator��$�� ��$��	10,0,12,0q�$	��Top=�#���  $��1��0 �� ? �� EndPoint$	? 1,1&�@ �� 
StartPoint$	@ 0,1&�.��� A � Color$A Black��B � Offset$	B 0.8Q�� $B 1Q�� $A Black��$	B 0.2Q�� �� -   C ��Name$C checkboxComplexType��$��Complex type��$��
0, 5, 0, 0q�$��Center=�$��Center=�$��99��� $��25��$��0,10,0,0q�.+��� #���  $��1q�$ 
3, 0, 0, 3��$��
10,0,109,0q�._���  . #���  ��Z� ��Z� .��Type�� -	   D ��Name$D comboboxComplexType��$��	70,0,10,0q�.@��� .��Primitive type� $��25��$��	10,5,10,0q�$	��Top=� �� $	��10* ��� $	��29* �.+��� #���  $��1q�$ 
3, 0, 0, 3��._���  . #���  ��Z� ��Z� .��
Identifier�� -
   $ gridIf��#���  $��
0, 1, 1, 1q�$ 
0, 3, 3, 0��#���  $��1��._��� -   $ textBoxIdentifier��#���  ��Z� ��Z� 