   M S B A M L   `   `   `  ���� J  FResourceClasses, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null|Oclr-namespace:VisualApplicationBuilder.ResourceClasses;assembly=ResourceClasses(VisualApplicationBuilder.ResourceClasses   	BlocksAll/   )VisualApplicationBuilder.Block.UsingBlock   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     gUserControlOclr-namespace:VisualApplicationBuilder.ResourceClasses;assembly=ResourceClasses     -   8   2VisualApplicationBuilder.ResourceClasses.BlockBase   Name$  blockControl��$��74.833��$	��400�� � 	Resources    ComboBoxToggleButton �� 
TargetType � ColumnDefinitions ��Name �� CornerRadius  BorderBrush  	BlueBrush  BackgroundBrush F�Name  ComboBoxTextBox �� 
TargetType �� Property	 �� Value
 d�Name �� 	ClickMode d� 	IsChecked �� Mode �� RelativeSource ��Name J� IsHitTestVisible �� SelectionBoxItem �� SelectionBoxItemTemplate ��Name �� 
IsReadOnly �� 
IsReadOnly �Name �� IsDropDownOpen � AllowsTransparency �Name J� SnapsToDevicePixels � ActualWidth �� MaxDropDownHeight K� IsItemsHost-  'System.Windows.Input.KeyboardNavigation   DirectionalNavigation �� Triggers  P� Property! P� Value" �� 
TargetName# P� 
SourceName$ �� Padding  PressedBrush  DisabledControlLightColor  DisabledControlDarkColor  DisabledForegroundBrush% �� Color 	 DisabledBackgroundBrush 
 DisabledBorderBrush��%�  &	        &	     '�� L    7   7  '�� �    &	 �    &	 �    &	 �    &	 �    &	     &	     &	 *    &		 :    &	
 J    �� " d�.R��  �� �� $��40 �.+��� $ Border��$��2��$ 3��#���  #���  $��1q��� $��0��$ 3��$��1q�#���  #���  $��0,0,1,0q�F� $ Arrow��$��1��#���  $��Center=�$��Center=�=����        �    �� � 	= ��[ � z �� � z     � 	=  	= 	�� " ��.R��� $ PART_ContentHost��|�.  #��z���� " ��.���  �@J�SnapsToDevicePixels	 . ��  �@�OverridesDefaultStyle	 . ��  � ��$
	 Auto=���  � ��$
	 Auto=���  � ��	 . ��  � ��$		 120����  � ��$	 20����  � ��
	 �������  � ��	 �� " ��.R�� .+�d� $
 ToggleButton��8��  $��2��|�.  $ Press=� �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+�� $ ContentSite�� .  #��z #��z #��z��$��3,3,23,3q�$��Center=�$
��Left=��� $ PART_EditableTextBox��8�� $
��Left=�$��Center=�$��3,3,23,3q�|�. ���	#FF3F3F3F
��� � �$y�Hidden=�# z ��Z� � $ Popup��$��Bottom=�#��z  . |�.  $��Slide=�.��� $ DropDown�� . #��z #��z .+��� $ DropDownBorder��#���  $ 5��$��1q�#���  �� $��4,6,4,6q� . .����  . $ 	Contained=� P�   �@��HasItems! .  . ��� $" DropDownBorder�� � ��$	 95��P�   � {�! .  . ���  � ��	 �#888888P�   �@��
IsGrouping! . . ���  � ��	 .  P� $# Popup��  �@�AllowsTransparency! . . ��� $" DropDownBorder�� �@��CornerRadius$	 0���� $" DropDownBorder�� � ��$	 0,2,0,0q�P�   �@��
IsEditable! . . ���  � ��	 .  �� $" PART_EditableTextBox�� � y�$	 Visible=��� $" ContentSite�� � y�$	 Hidden=��� " ��.���  �@J�SnapsToDevicePixels	 . ��  � ��
	 �������  �@�OverridesDefaultStyle	 . ��  � ��	 �� " ��.R��� $ Border��$$ 2q� . ._���  P�   �@��IsHighlighted! . . ��� $" Border��#	 �   � ��P�   � {�! .  . ��� #	 �   � ����#222����LightSteelBlue����	#FF007ACC����#EEE����	#FFE8EDF9����	#FFC5CBF9���� $
% #888���� $
% #EEE���� $
% #AAA��.���� -   $ borderOuter��#���  #���  $��1q�$ 10��$��0,0,1,-1q�._��� -   & ��Name$& stackPanelOuter��$��-1q�.+�� $��30��.+��� -   ' ��Name$' labelBlockName��$��Using��$
��Left=�$��26,1,0,0q�$	��Top=����	#FFBFBFBF$��26��$��61��A� -   ( A�Name$( statusIndicator��$
��Left=�$��17��$��17��$��10,6,0,0q����	#FF007ACC$	��Top=��� -   ) ��Name$) buttonRemoveBlock��$��0,2,10,0q�$	��Top=�$��25��$��25��
���""��$��Right=���Z� ��Z� * J� OpacityMask* L� + �� RelativeTransform+ V� .~��� , �� CenterY$	, 0.5Q�- �� CenterX$	- 0.5Q�. �� ScaleX$	. 0.8Q�/ �� ScaleY$	/ 0.8Q��� 0 �� CenterY$	0 0.5Q�1 �� CenterX$	1 0.5Q��� 2 �� CenterY$	2 0.5Q�3 �� CenterX$	3 0.5Q�T� 4 L� Drawing4 I� .��� 
5 � Pen5 >� 6 >� 	Thickness$6 5Q�7 >� Brush
7 �   �8 � Geometry8 @� 9 @� RadiusX$9 20Q�: @� RadiusY$: 20Q�� +8 ��@0��@0�����j ��j ���j @0���@0����j 	5 >� $6 5Q�
7 �   ��� -   $' labelSeparator��$�� ��$��	10,0,12,0q�$	��Top=�#���  $��1��* �� ; �� EndPoint$	; 1,1&�< �� 
StartPoint$	< 0,1&�.��� = � Color$= Black��> � Offset$	> 0.8Q�� $> 1Q�� $= Black��$	> 0.2Q�� �� ? �� Orientation$? 
Horizontal=�$��25��$��0,10,0,0q�.+��� -   @ ��Name$@ comboboxMainNS��$��10, 0, 10, 0q�$	��197���� -	   $@ comboboxNSS��$	��170��