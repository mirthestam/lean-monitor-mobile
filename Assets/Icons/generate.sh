#!/bin/bash

white='FFFFFF'
black='000000'
light='333333'
dark='AAAAAA'

export_file() {    
    export_to_color $1 black $black
    export_to_color $1 white $white
    export_to_color $1 light $light
    export_to_color $1 dark $dark
}

export_to_color() {
               
    # Create SVG for this color
    sed "s/ff0000/$3/g" $1.svg > $1-$2.svg    
    
    echo $3
    echo $1
    echo $2    
    echo ---

    # Export android images
    export_from_svg $1-$2 ./android/drawable-mdpi/$1-18-$2.png 18    
    export_from_svg $1-$2 ./android/drawable-mdpi/$1-24-$2.png 24
    export_from_svg $1-$2 ./android/drawable-mdpi/$1-36-$2.png 36
    export_from_svg $1-$2 ./android/drawable-mdpi/$1-48-$2.png 48
    
    export_from_svg $1-$2 ./android/drawable-hdpi/$1-18-$2.png 27    
    export_from_svg $1-$2 ./android/drawable-hdpi/$1-24-$2.png 36
    export_from_svg $1-$2 ./android/drawable-hdpi/$1-36-$2.png 54
    export_from_svg $1-$2 ./android/drawable-hdpi/$1-48-$2.png 72
    
    export_from_svg $1-$2 ./android/drawable-xhdpi/$1-18-$2.png 36    
    export_from_svg $1-$2 ./android/drawable-xhdpi/$1-24-$2.png 48
    export_from_svg $1-$2 ./android/drawable-xhdpi/$1-36-$2.png 72
    export_from_svg $1-$2 ./android/drawable-xhdpi/$1-48-$2.png 96

    export_from_svg $1-$2 ./android/drawable-xxhdpi/$1-18-$2.png 54    
    export_from_svg $1-$2 ./android/drawable-xxhdpi/$1-24-$2.png 72
    export_from_svg $1-$2 ./android/drawable-xxhdpi/$1-36-$2.png 108
    export_from_svg $1-$2 ./android/drawable-xxhdpi/$1-48-$2.png 144    
}

export_from_svg() {
    inkscape --file $1.svg --export-png $2 --export-width $3
}

export_file baseline-dashboard
export_file baseline-work
export_file baseline-description
export_file baseline-swap_horiz

