   M S B A M L   `   `   `  ����J  FResourceClasses, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null|Oclr-namespace:VisualApplicationBuilder.ResourceClasses;assembly=ResourceClasses(VisualApplicationBuilder.ResourceClasses  5       	BlocksAll-   'VisualApplicationBuilder.Block.ForBlock   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      gUserControlOclr-namespace:VisualApplicationBuilder.ResourceClasses;assembly=ResourceClasses     5      -   5        8   2VisualApplicationBuilder.ResourceClasses.BlockBase   Name$  blockControl��5      $	��400��5      $	��300��6+    � 	Resources 5
         BackgroundBrush  BorderBrush  	BlueBrush��%�   &	        &	      &	 B     ��5   
   #222��68   ��5   
   LightSteelBlue��6>   ��5   
   	#FF007ACC��67   5      .��5      �� -   5         ��Name$ borderOuter��5      #���   6"   #���  6Q   $��1q�6}    �� CornerRadius$ 10��6�   ._�5   
   �� -   5         ��Name$ stackPanelOuter��5      .+�5      � $��30��6   .+�5      �� -   5         ��Name$ labelBlockName��5      $��	Iteration��60   $
��Left=�6D   $��30,1,0,0q�6_   $	��Top=�6q   ���	#FFBFBFBF$��26��6�   $��55��6�   A� 5      -   5         A�Name$ statusIndicator��5      $
��Left=�63   $��17��6N   $��17��6Z   $��10,6,0,0q�6e   ���	#FF007ACC$	��Top=�6�   �� 5      -   5         ��Name$ buttonRemoveBlock��5   Y   $��0,2,9,0q�6   $	��Top=�6*   $��25��6B   $��25��6N   
���""�� J� RenderTransformOrigin$ 	0.4,0.498&�6�   $��Right=�6�   ��6t   Z� ��6�   Z� 	 J� OpacityMask	 5      L� 5      
 �� RelativeTransform
 5      V� 5   "   .~�5   &   ��  �� CenterY$	 0.5Q�65    �� CenterX$	 0.5Q�6C    �� ScaleX$	 0.8Q�6Q    �� ScaleY$	 0.8Q�6^   �� 5   &    �� CenterY$	 0.5Q�64    �� CenterX$	 0.5Q�6B   �� 5   &    �� CenterY$	 0.5Q�66    �� CenterX$	 0.5Q�6D   T� 5   &   5   #    L� Drawing 5!      I� 5"   "   .��5#   &   � 
 � Pen 5$   *   >� 5%   .    >� 	Thickness$ 5Q�62    >� Brush
 �   �6@    � Geometry 5(   *   @� 5)   .    @� RadiusX$ 20Q�6>    @� RadiusY$ 20Q�6K   5+   '   � 5-   &   + ��@0��@0�����j ��j ���j @0���@0����j 	 5.   *   >� 5/   .   $ 5Q�62   
 �   �6@   52   '   53   #   55      57      58      �� 59      -   5        $ labelSeparator��59      $�� ��6,   $��	10,0,12,0q�67   $	��Top=�6J   #���  6b   $��1��6�   	 5:      �� 5;       �� EndPoint$	 1,1&�6*    �� 
StartPoint$	 0,1&�69   .��5<      �  � Color$ Black��6'    � Offset$	 0.8Q�65   � 5=      $ 1Q�6'   � 5>      $ Black��6'   $	 0.2Q�65   � 5?      5@      5B      � 5E      $��24��6   $��	10,5,10,0q�6   $	��Top=�62    � ColumnDefinitions 5F      �� 5G      $	��38* �6'   �� 5H      $
��101* �6'   .+�5J      �� #���  6   $��1q�6C   $ 
3, 0, 0, 3��6W   ._�5K      ��  �� 
IsReadOnly . #���  6]   ��6   Z� ��64   Z� .��6�   Initialization6�   5L      �� 5M      -   5        $ gridInitialization��5M      #���  65   $��
0, 1, 1, 1q�6_   $ 
0, 3, 3, 0��6|   #���  6�   $��1��6�   ._�5N      �� -	   5          ��Name$  textBoxInitialization��5N      #���   6j   $#��Type initialization statement��6�   ��6=   Z� ��6T   Z� 6�   5O      5P      � 5R      $��24��6   $��	10,5,10,0q�6   $	��Top=�62    5S      �� 5T      $	��38* �6'   �� 5U      $
��101* �6'   .+�5W      �� #���  6   $��1q�6C   $ 
3, 0, 0, 3��6W   ._�5X      ��  . #���  6]   $��	Condition��6�   ��6   Z� ��64   Z� 6�   5Y      �� 5Z      -
   5        $ gridCondition��5Z      #���  60   $��
0, 1, 1, 1q�6Z   $ 
0, 3, 3, 0��6w   #���  6�   $��1��6�   ._�5[      �� -   5        $  textBoxCondition��5[      #���   6e   ��68   Z� ��6O   Z� .��6�   Type conditional statement6�   5\      5]      � 5_      $��24��6   $��	10,5,10,0q�6   $	��Top=�62    5`      �� 5a      $	��38* �6'   �� 5b      $
��101* �6'   .+�5d      �� #���  6   $��1q�6C   $ 
3, 0, 0, 3��6W   ._�5e      ��  . #���  6]   $��	Increment��6�   ��6   Z� ��64   Z� 6�   5f      �� 5g      -   5        $ gridIncrement��5g      #���  60   $��
0, 1, 1, 1q�6Z   $ 
0, 3, 3, 0��6w   #���  6�   $��1��6�   ._�5h      �� -   5        $  textBoxIncrement��5h      #���   6e   ��68   Z� ��6O   Z� .��6�   Type increment statement6�   5i      5j      � 5l      -   5        ! �Name$! gridBody��5l      $��
10,10,10,0q�6%   $	��161��69   $	��Top=�6F   .+�5m      �� #���  6   $ 
3, 3, 0, 0��6C   $��1q�6]   $��25��6q   $	��Top=�6}   ._�5n      ��  . #���  6]   ��6   Z� ��64   Z� .��6�   Body6�   5o      �� 5p      #���  6   $ 
0, 0, 3, 3��6C   $��
1, 0, 1, 1q�6]   $��0,25,0,0q�6z   ._�5q      �� -   5        $ stackPanelBody��5q   !   5r      5s      5w      5x      5y      