   M S B A M L   `   `   `  ����J  FResourceClasses, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null|Oclr-namespace:VisualApplicationBuilder.ResourceClasses;assembly=ResourceClasses(VisualApplicationBuilder.ResourceClasses  5       	BlocksAll/   )VisualApplicationBuilder.Block.UsingBlock   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      gUserControlOclr-namespace:VisualApplicationBuilder.ResourceClasses;assembly=ResourceClasses     5      -   5        8   2VisualApplicationBuilder.ResourceClasses.BlockBase   Name$  blockControl��5      $��74.833��5      $	��400��6/    � 	Resources 5
         ComboBoxToggleButton �� 
TargetType � ColumnDefinitions ��Name �� CornerRadius  BorderBrush  	BlueBrush  BackgroundBrush F�Name  ComboBoxTextBox �� 
TargetType �� Property	 �� Value
 d�Name �� 	ClickMode d� 	IsChecked �� Mode �� RelativeSource ��Name J� IsHitTestVisible �� SelectionBoxItem �� SelectionBoxItemTemplate ��Name �� 
IsReadOnly �� 
IsReadOnly �Name �� IsDropDownOpen � AllowsTransparency �Name J� SnapsToDevicePixels � ActualWidth �� MaxDropDownHeight K� IsItemsHost-  'System.Windows.Input.KeyboardNavigation   DirectionalNavigation �� Triggers  P� Property! P� Value" �� 
TargetName# P� 
SourceName$ �� Padding  PressedBrush  DisabledControlLightColor  DisabledControlDarkColor  DisabledForegroundBrush% �� Color 	 DisabledBackgroundBrush 
 DisabledBorderBrush��%�  &	        &	     '�� |    7   7  '�� �
    &	     &	 ,    &	 R    &	 s    &	 �    &	 �    &	 �    &		 �    &	
     �� 5   
   " d�67   .R�5      �  5      �� 5      �� 5      $��40 �6'   .+�5      �� $ Border��5      $��2��5      $ 3��5      #���  5      #���  5      $��1q�5      �� 5      $��0��5      $ 3��5      $��1q�5      #���  5      #���  5      $��0,0,1,0q�5       F� 5!      $ Arrow��5"      $��1��5#      #���  5$      $��Center=�5%      $��Center=�5&      =����        �    �� � 	= ��[ � z �� � z     � 	=  	= 	5'      5)      5*      �� 5,   
   " ��62   .R�5-      �� $ PART_ContentHost��6   |�.  #��z��6A   5.      �� 51   
   " ��6*   .�52      ��  �@J�SnapsToDevicePixels	 . 64   �� 53       �@�OverridesDefaultStyle	 . 66   �� 54       � ��$
	 Auto=�6K   �� 55       � ��$
	 Auto=�6I   �� 56       � ��	 . 6>   �� 57       � ��$		 120��6)   �� 58       � ��$	 20��6*   �� 59       � ��
	 �����6+   �� 5:       � ��	 5;      �� 5<      " ��6&   .R�5=      � .+�5>      d� $
 ToggleButton��5?      8��  $��2��5A      |�.  $ Press=�5D       5C      �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+5D      �� 5E      $ ContentSite��6/    .  #��z 6^   #��z 5F      #��z��5G      $��3,3,23,3q�5H      $��Center=�5I      $
��Left=�5J      �� 5K      $ PART_EditableTextBox��6&   8�� $
��Left=�5N      $��Center=�5O      $��3,3,23,3q�5P      |�. ���	#FF3F3F3F
��� � �$y�Hidden=�5T      # z 5U      ��5L      Z� 5U      � 5V      $ Popup��5W      $��Bottom=�5X      #��z 5Y       . |�.  $��Slide=�5\      .��5^   "   � $ DropDown��6'    . #��z 5`      #��z 5a      .+�5b   &   �� $ DropDownBorder��5c      #���  5d      $ 5��5e      $��1q�5f      #���  5g      �� 5h   &   $��4,6,4,6q�63    . .��5i   *   ��  . $ 	Contained=�6H   5j   '   5k   #   5l      5m       5n      P� 5o        �@��HasItems! .  . �5p   "   �� $" DropDownBorder��6)    � ��$	 95��6Z   5q      P� 5r        � {�! .  . �5s   "   ��  � ��	 �#8888886?   5t      P� 5u        �@��
IsGrouping! . . �5v   "   ��  � ��	 .  6R   5w      P� 5x      $# Popup��6&     �@�AllowsTransparency! . . �5y   "   �� $" DropDownBorder��6)    �@��CornerRadius$	 0��6]   �� 5z   "   $" DropDownBorder��6)    � ��$	 0,2,0,0q�6W   5{      P� 5|        �@��
IsEditable! . . �5}   "   ��  � ��	 .  6>   �� 5~   "   $" PART_EditableTextBox��6)    � y�$	 Visible=�6a   �� 5   "   $" ContentSite��6)    � y�$	 Hidden=�6X   5�      5�      5�      5�      �� 5�   
   " ��6.   .�5�      ��  �@J�SnapsToDevicePixels	 . 64   �� 5�       � ��
	 �����6+   �� 5�       �@�OverridesDefaultStyle	 . 66   �� 5�       � ��	 5�      �� 5�      " ��6&   .R�5�      �� $ Border��6!   $$ 2q�5�       . ._�5�      �� 5�       5�      P� 5�        �@��IsHighlighted! . . �5�   "   �� $" Border��6)   #	 �  6S    � ��5�      P� 5�        � {�! .  . �5�   "   �� #	 �  6?    � ��5�      5�      5�      5�      ��5�   
   #222��68   ��5�   
   LightSteelBlue��6>   ��5�   
   	#FF007ACC��67   ��5�   
   #EEE��65   ��5�   
   	#FFE8EDF9��6=   ��5�   
   	#FFC5CBF9��6<   �� 5�   
   $
% #888��6:   �� 5�   
   $
% #EEE��6:   �� 5�   
   $
% #AAA��66   5�      .��5�      �� -   5        $ borderOuter��5�      #���  6"   #���  6Q   $��1q�6}   $ 10��6�   $��0,0,1,-1q�6�   ._�5�   
   �� -   5        & ��Name$& stackPanelOuter��5�      $��-1q�6.   .+�5�      � $��30��6   .+�5�      �� -   5        ' ��Name$' labelBlockName��5�      $��Using��60   $
��Left=�6@   $��26,1,0,0q�6[   $	��Top=�6m   ���	#FFBFBFBF$��26��6�   $��61��6�   A� 5�      -   5        ( A�Name$( statusIndicator��5�      $
��Left=�63   $��17��6N   $��17��6Z   $��10,6,0,0q�6e   ���	#FF007ACC$	��Top=�6�   �� 5�      -   5        ) ��Name$) buttonRemoveBlock��5�   Z   $��0,2,10,0q�6   $	��Top=�6+   $��25��6C   $��25��6O   
���""��$��Right=�6�   ��6u   Z� ��6�   Z� * J� OpacityMask* 5�      L� 5�      + �� RelativeTransform+ 5�      V� 5�   "   .~�5�   &   �� , �� CenterY$	, 0.5Q�65   - �� CenterX$	- 0.5Q�6C   . �� ScaleX$	. 0.8Q�6Q   / �� ScaleY$	/ 0.8Q�6^   �� 5�   &   0 �� CenterY$	0 0.5Q�64   1 �� CenterX$	1 0.5Q�6B   �� 5�   &   2 �� CenterY$	2 0.5Q�66   3 �� CenterX$	3 0.5Q�6D   T� 5�   &   5�   #   4 L� Drawing4 5�      I� 5�   "   .��5�   &   � 
5 � Pen5 5�   *   >� 5�   .   6 >� 	Thickness$6 5Q�62   7 >� Brush
7 �   �6@   8 � Geometry8 5�   *   @� 5�   .   9 @� RadiusX$9 20Q�6>   : @� RadiusY$: 20Q�6K   5�   '   � 5�   &   +8 ��@0��@0�����j ��j ���j @0���@0����j 	5 5�   *   >� 5�   .   $6 5Q�62   
7 �   �6@   5�   '   5�   #   5�      5�      5�      �� 5�      -   5        $' labelSeparator��5�      $�� ��6,   $��	10,0,12,0q�67   $	��Top=�6J   #���  6b   $��1��6�   * 5�      �� 5�      ; �� EndPoint$	; 1,1&�6*   < �� 
StartPoint$	< 0,1&�69   .��5�      � = � Color$= Black��6'   > � Offset$	> 0.8Q�65   � 5�      $> 1Q�6'   � 5�      $= Black��6'   $	> 0.2Q�65   � 5�      5�      5�      �� 5�      ? �� Orientation$? 
Horizontal=�6   $��25��62   $��0,10,0,0q�6>   .+�5�      �� -   5        @ ��Name$@ comboboxMainNS��5�      $��10, 0, 10, 0q�63   $	��197��6I   6U   �� 5�      -	   5        $@ comboboxNSS��5�      $	��170��60   5�      5�      5�      5�      