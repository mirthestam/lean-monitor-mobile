export_platforms() {
    export_android $1 $2
    # todo export IOS
}

export_android() { 
    export_android_res mdpi $1 $2
    export_android_res hdpi $1 $2
    export_android_res xhdpi $1 $2
    export_android_res xxhdpi $1 $2    
}

export_android_res() {   
    cp android/drawable-$1/$2-$3* ../../LeanMobileProto/LeanMobileProto.Android/Resources/drawable-$1/
}

export_platforms baseline-work 24 
export_platforms baseline-swap_horiz 24 
export_platforms baseline-dashboard 24 
export_platforms baseline-description 24 