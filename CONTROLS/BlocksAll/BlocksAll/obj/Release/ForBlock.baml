   M S B A M L   `   `   `  ���� J  FResourceClasses, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null|Oclr-namespace:VisualApplicationBuilder.ResourceClasses;assembly=ResourceClasses(VisualApplicationBuilder.ResourceClasses   	BlocksAll-   'VisualApplicationBuilder.Block.ForBlock   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     gUserControlOclr-namespace:VisualApplicationBuilder.ResourceClasses;assembly=ResourceClasses     -   8   2VisualApplicationBuilder.ResourceClasses.BlockBase   Name$  blockControl��$	��400��$	��300�� � 	Resources    BackgroundBrush  BorderBrush  	BlueBrush��%W   &	        &	      &	 &     ��#222����LightSteelBlue����	#FF007ACC��.���� -    ��Name$ borderOuter��#���   #���  $��1q� �� CornerRadius$ 10��._��� -    ��Name$ stackPanelOuter��.+�� $��30��.+��� -    ��Name$ labelBlockName��$��	Iteration��$
��Left=�$��30,1,0,0q�$	��Top=����	#FFBFBFBF$��26��$��55��A� -    A�Name$ statusIndicator��$
��Left=�$��17��$��17��$��10,6,0,0q����	#FF007ACC$	��Top=��� -    ��Name$ buttonRemoveBlock��$��0,2,9,0q�$	��Top=�$��25��$��25��
���""�� J� RenderTransformOrigin$ 	0.4,0.498&�$��Right=���Z� ��Z� 	 J� OpacityMask	 L� 
 �� RelativeTransform
 V� .~���  �� CenterY$	 0.5Q� �� CenterX$	 0.5Q� �� ScaleX$	 0.8Q� �� ScaleY$	 0.8Q���  �� CenterY$	 0.5Q� �� CenterX$	 0.5Q���  �� CenterY$	 0.5Q� �� CenterX$	 0.5Q�T�  L� Drawing I� .��� 
 � Pen >�  >� 	Thickness$ 5Q� >� Brush
 �   � � Geometry @�  @� RadiusX$ 20Q� @� RadiusY$ 20Q�� + ��@0��@0�����j ��j ���j @0���@0����j 	 >� $ 5Q�
 �   ��� -   $ labelSeparator��$�� ��$��	10,0,12,0q�$	��Top=�#���  $��1��	 ��  �� EndPoint$	 1,1&� �� 
StartPoint$	 0,1&�.���  � Color$ Black�� � Offset$	 0.8Q�� $ 1Q�� $ Black��$	 0.2Q�� � $��24��$��	10,5,10,0q�$	��Top=� � ColumnDefinitions �� $	��38* ��� $
��101* �.+��� #���  $��1q�$ 
3, 0, 0, 3��._���  �� 
IsReadOnly . #���  ��Z� ��Z� .��Initialization�� -   $ gridInitialization��#���  $��
0, 1, 1, 1q�$ 
0, 3, 3, 0��#���  $��1��._��� -	     ��Name$  textBoxInitialization��#���   $#��Type initialization statement����Z� ��Z� � $��24��$��	10,5,10,0q�$	��Top=� �� $	��38* ��� $
��101* �.+��� #���  $��1q�$ 
3, 0, 0, 3��._���  . #���  $��	Condition����Z� ��Z� �� -
   $ gridCondition��#���  $��
0, 1, 1, 1q�$ 
0, 3, 3, 0��#���  $��1��._��� -   $  textBoxCondition��#���   ��Z� ��Z� .��Type conditional statement� $��24��$��	10,5,10,0q�$	��Top=� �� $	��38* ��� $
��101* �.+��� #���  $��1q�$ 
3, 0, 0, 3��._���  . #���  $��	Increment����Z� ��Z� �� -   $ gridIncrement��#���  $��
0, 1, 1, 1q�$ 
0, 3, 3, 0��#���  $��1��._��� -   $  textBoxIncrement��#���   ��Z� ��Z� .��Type increment statement� -   ! �Name$! gridBody��$��
10,10,10,0q�$	��161��$	��Top=�.+��� #���  $ 
3, 3, 0, 0��$��1q�$��25��$	��Top=�._���  . #���  ��Z� ��Z� .��Body�� #���  $ 
0, 0, 3, 3��$��
1, 0, 1, 1q�$��0,25,0,0q�._��� -   $ stackPanelBody��