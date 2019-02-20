#!/bin/bash

#light theme
light_tabs='337AB7'

# dark theme
dark_tabs='C2C2C2'

export_to_color() {
               
    # Create SVG for this color
    sed "s/ff0000/$3/g" $1.svg > $1-$2.svg    
    
    echo $4
    
    # Export android images
    if [ "$4" == "18" ]; then
        export_from_svg $1-$2 ./android/drawable-mdpi/$1-18-$2.png 18
        export_from_svg $1-$2 ./android/drawable-hdpi/$1-18-$2.png 27
        export_from_svg $1-$2 ./android/drawable-xhdpi/$1-18-$2.png 36
        export_from_svg $1-$2 ./android/drawable-xxhdpi/$1-18-$2.png 54
    fi         

    if [ "$4" == "24" ]; then
        export_from_svg $1-$2 ./android/drawable-mdpi/$1-24-$2.png 24        
        export_from_svg $1-$2 ./android/drawable-hdpi/$1-24-$2.png 36
        export_from_svg $1-$2 ./android/drawable-xhdpi/$1-24-$2.png 48    
        export_from_svg $1-$2 ./android/drawable-xxhdpi/$1-24-$2.png 72    
    fi
    
    if [ "$4" == "36" ]; then
        export_from_svg $1-$2 ./android/drawable-mdpi/$1-36-$2.png 36
        export_from_svg $1-$2 ./android/drawable-hdpi/$1-36-$2.png 54
        export_from_svg $1-$2 ./android/drawable-xhdpi/$1-36-$2.png 72
        export_from_svg $1-$2 ./android/drawable-xxhdpi/$1-36-$2.png 108
    fi

    if [ "$4" == "48" ]; then
        export_from_svg $1-$2 ./android/drawable-mdpi/$1-48-$2.png 48
        export_from_svg $1-$2 ./android/drawable-hdpi/$1-48-$2.png 72
        export_from_svg $1-$2 ./android/drawable-xhdpi/$1-48-$2.png 96
        export_from_svg $1-$2 ./android/drawable-xxhdpi/$1-48-$2.png 144  
    fi  
}

export_from_svg() {
    inkscape --file $1.svg --export-png $2 --export-width $3
}

# Export all required images here
export_to_color baseline-dashboard light $light_tabs 24
export_to_color baseline-dashboard dark $dark_tabs 24

export_to_color baseline-work light $light_tabs 24 
export_to_color baseline-work dark $dark_tabs 24

export_to_color baseline-description light $light_tabs 24
export_to_color baseline-description dark $dark_tabs 24

export_to_color baseline-swap_horiz light $light_tabs 24
export_to_color baseline-swap_horiz dark $dark_tabs 24

