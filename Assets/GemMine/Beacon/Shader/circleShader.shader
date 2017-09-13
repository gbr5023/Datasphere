Shader "GemMine/CircleShader" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Tint ("Tint", Color) = (1.0,1.0,1.0,1.0)
		_Radius ( "Radius", Range ( 0, 1 ) ) = 0.5
		_Alpha ("Alpha", Range (0,1)) = 1
	}
	SubShader {
		Tags { "RenderType"="Transparent" "Queue" = "Transparent"}
		//Cull Off
		LOD 200
		
		//Blend SrcAlpha OneMinusSrcAlpha
		CGPROGRAM
		#pragma surface surf Lambert alpha

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		// main Texture (not used)
		sampler2D _MainTex;
		// color of zenCircle
		float4 _Tint;
		// radius of circle
		float _Radius;
		// Alpha value of the ring
		float _Alpha;

		struct Input {
			float2 uv_MainTex;
		};


		void surf (Input IN, inout SurfaceOutput o) {
			// max size of circle is 0.7
			float circleSize = 0.7f;
			// center point of the texture
			float2 centerPoint = float2(0.5f, 0.5f);
			// radius of expanding circle
			// ATTENTION: use _BLEND for radius of circle
			float radius = _Radius * circleSize;
			// aspect ratio
			float aspectRatio = 800.0f/800.0f;
			// calculate the length of
			// actual pixel to center of circle
			float fromCenter = length((IN.uv_MainTex - centerPoint)/float2(1, aspectRatio));  
			// get current texture pixel
			half4 c1 = tex2D (_MainTex, IN.uv_MainTex);
			// if current Pixel is greater than the current radius 
			// with a thickness of 0.005
			o.Emission = _Tint.rgb; 
			if ((fromCenter - radius > 0.0) || (fromCenter - radius < -0.1)) {
			  // make pixel transparent
			  o.Albedo = _Tint.rgb;
			  o.Alpha = 0.0;
			}
			else {
			  // draw the zen circle in the given color
			  o.Albedo = _Tint.rgb;
			  o.Alpha = _Alpha;
			}
		}


		ENDCG
	} 
	FallBack "Diffuse"
}
