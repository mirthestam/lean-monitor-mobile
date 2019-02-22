#!/bin/bash
export_to_color() {
               
    # Create SVG for this color
    sed "s/ff0000/$3/g" $1.svg > $1-$2.svg    
    
    echo $4
    
    # Export android images
    if [ "$4" == "18" ]; then
        export_from_svg $1-$2 ./android/drawable-mdpi/$1_18_$2.png 18
        export_from_svg $1-$2 ./android/drawable-hdpi/$1_18_$2.png 27
        export_from_svg $1-$2 ./android/drawable-xhdpi/$1_18_$2.png 36
        export_from_svg $1-$2 ./android/drawable-xxhdpi/$1_18_$2.png 54
    fi         

    if [ "$4" == "24" ]; then
        export_from_svg $1-$2 ./android/drawable-mdpi/$1_24_$2.png 24        
        export_from_svg $1-$2 ./android/drawable-hdpi/$1_24_$2.png 36
        export_from_svg $1-$2 ./android/drawable-xhdpi/$1_24_$2.png 48    
        export_from_svg $1-$2 ./android/drawable-xxhdpi/$1_24_$2.png 72    
    fi
    
    if [ "$4" == "36" ]; then
        export_from_svg $1-$2 ./android/drawable-mdpi/$1_36_$2.png 36
        export_from_svg $1-$2 ./android/drawable-hdpi/$1_36_$2.png 54
        export_from_svg $1-$2 ./android/drawable-xhdpi/$1_36_$2.png 72
        export_from_svg $1-$2 ./android/drawable-xxhdpi/$1_36_$2.png 108
    fi

    if [ "$4" == "48" ]; then
        export_from_svg $1-$2 ./android/drawable-mdpi/$1_48_$2.png 48
        export_from_svg $1-$2 ./android/drawable-hdpi/$1_48_$2.png 72
        export_from_svg $1-$2 ./android/drawable-xhdpi/$1_48_$2.png 96
        export_from_svg $1-$2 ./android/drawable-xxhdpi/$1_48_$2.png 144  
    fi  
    
    if [ "$4" == "100" ]; then
        export_from_svg $1-$2 ./android/drawable-mdpi/$1_100_$2.png 100
        export_from_svg $1-$2 ./android/drawable-hdpi/$1_100_$2.png 150
        export_from_svg $1-$2 ./android/drawable-xhdpi/$1_100_$2.png 200
        export_from_svg $1-$2 ./android/drawable-xxhdpi/$1_100_$2.png 300  
    fi  
    
}

export_from_svg() {
    inkscape --file $1.svg --export-png $2 --export-width $3
}

# Logo
logo='FF9900'
export_to_color Lean light $logo 100

# Main Menu
light_menu='337AB7'
dark_menu='C2C2C2'
export_to_color baseline_flash_on light $light_menu 24
export_to_color baseline_flash_on dark $dark_menu 24

export_to_color baseline_folder light $light_menu 24
export_to_color baseline_folder dark $dark_menu 24

export_to_color baseline_help light $light_menu 24
export_to_color baseline_help dark $dark_menu 24

export_to_color baseline_settings light $light_menu 24
export_to_color baseline_settings dark $dark_menu 24

# Live tabs
light_tabs='337AB7'
dark_tabs='C2C2C2'
export_to_color baseline_dashboard light $light_tabs 24
export_to_color baseline_dashboard dark $dark_tabs 24

export_to_color baseline_work light $light_tabs 24 
export_to_color baseline_work dark $dark_tabs 24

export_to_color baseline_description light $light_tabs 24
export_to_color baseline_description dark $dark_tabs 24

export_to_color baseline_swap_horiz light $light_tabs 24
export_to_color baseline_swap_horiz dark $dark_tabs 24



