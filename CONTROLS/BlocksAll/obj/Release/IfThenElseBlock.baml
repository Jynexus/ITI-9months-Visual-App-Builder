   M S B A M L   `   `   `  ���� J  FResourceClasses, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null|Oclr-namespace:VisualApplicationBuilder.ResourceClasses;assembly=ResourceClasses(VisualApplicationBuilder.ResourceClasses   	BlocksAll4   .VisualApplicationBuilder.Block.ifThenElseBlock   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     gUserControlOclr-namespace:VisualApplicationBuilder.ResourceClasses;assembly=ResourceClasses     -   8   2VisualApplicationBuilder.ResourceClasses.BlockBase   Name$  blockControl��$	��400��$��328.333�� � 	Resources    BackgroundBrush  BorderBrush  	BlueBrush��%W   &	        &	      &	 &     ��#222����LightSteelBlue����	#FF007ACC��.���� -    ��Name$ borderOuter��#���   #���  $��1q� �� CornerRadius$ 10��._��� -    ��Name$ stackPanelOuter��.+�� $��30��.+��� -    ��Name$ labelBlockName��$��	Condition��$
��Left=�$��30,1,0,0q�$	��Top=����	#FFBFBFBFA� -    A�Name$ statusIndicator��$
��Left=�$��17��$��17��$��10,6,0,0q����	#FF007ACC$	��Top=��� -    ��Name$ buttonRemoveBlock��$��0,2,9,0q�$	��Top=�$��25��$��25��
���""��$��Right=���Z� ��Z�  J� OpacityMask L� 	 �� RelativeTransform	 V� .~��� 
 �� CenterY$	
 0.5Q� �� CenterX$	 0.5Q� �� ScaleX$	 0.8Q� �� ScaleY$	 0.8Q���  �� CenterY$	 0.5Q� �� CenterX$	 0.5Q���  �� CenterY$	 0.5Q� �� CenterX$	 0.5Q�T�  L� Drawing I� .��� 
 � Pen >�  >� 	Thickness$ 5Q� >� Brush
 �   � � Geometry @�  @� RadiusX$ 20Q� @� RadiusY$ 20Q�� + ��@0��@0�����j ��j ���j @0���@0����j 	 >� $ 5Q�
 �   ��� -   $ labelSeparator��$�� ��$��	10,0,12,0q�$	��Top=�#���  $��1�� ��  �� EndPoint$	 1,1&� �� 
StartPoint$	 0,1&�.���  � Color$ Black�� � Offset$	 0.8Q�� $ 1Q�� $ Black��$	 0.2Q�� � $��25��$��	10,5,10,0q�$	��Top=� � ColumnDefinitions �� $	��21* ��� $
��257* �.+��� #���  $��1q�$ 
3, 0, 0, 3��._���  �� 
IsReadOnly . #���  ��Z� ��Z� .��if�� -   $ gridIf��#���  $��
0, 1, 1, 1q�$ 
0, 3, 3, 0��#���  $��1��._��� -	    ��Name$ textBoxCondition��#���   ��Z� ��Z� .��Type conditional statement� -
     �Name$  gridThen��$��
10,10,10,0q�$	��142��$	��Top=�.+��� #���  $ 
3, 3, 0, 0��$��1q�$��25��$	��Top=�._���  . #���  ��Z� ��Z� .��then�� #���  $ 
0, 0, 3, 3��$��
1, 0, 1, 1q�$��0,25,0,0q�._��� -   $ stackPanelThen��� -   $  gridElse��$��	10,5,10,0q�$��99��$	��Top=�.+��� #���  $ 
3, 3, 0, 0��$��1q�$��25��$	��Top=�._���  . #���  $
��else����Z� ��Z� �� #���  $ 
0, 0, 3, 3��$��
1, 0, 1, 1q�$��0,25,0,0q�._��� -   $ stackPanelElse��