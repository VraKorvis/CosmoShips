Shader "Custom/Starfield" {
	Properties {
		//_Color ("Color", Color) = (1,1,1,1)
		//_MainTex ("Albedo (RGB)", 2D) = "white" {}
		//_Glossiness ("Smoothness", Range(0,1)) = 0.5
		//_Metallic ("Metallic", Range(0,1)) = 0.0

		_Background ("Background (RGB)"   , 2D) = "black" {}
		_SmallStars ("Small Stars (RGBA)" , 2D) = "black" {}
		_MediumStars("Medium Stars (RGBA)", 2D) = "black" {}
		_BigStars   ("Big Stars (RGBA)"   , 2D) = "black" {}
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Lambert

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _Background;
		sampler2D _SmallStars;
		sampler2D _MediumStars;
		sampler2D _BigStars;

		struct Input {
		float2 uv_Background;
		float2 uv_SmallStars;
		float2 uv_MediumStars;
		float2 uv_BigStars;
		};

		void surf(Input IN, inout SurfaceOutput o) {
			half4 background  = tex2D (_Background , IN.uv_Background );
			half4 smallStars  = tex2D (_SmallStars , IN.uv_SmallStars );
			half4 mediumStars = tex2D (_MediumStars, IN.uv_MediumStars);
			half4 bigStars    = tex2D (_BigStars   , IN.uv_BigStars   );

			//Сумма цветов звезд без фона:
			half3 starAlbedo = smallStars.rgb * smallStars.a + mediumStars.rgb * mediumStars.a + bigStars.rgb * bigStars.a;
			 
			o.Albedo = background.rgb + starAlbedo;

			//мерцание от сразмера звезды
			half starAlpha = 
				smallStars .a * (2 + sin(IN.uv_SmallStars .x * IN.uv_SmallStars .y * 12 + _Time.w * 3)) + 
				mediumStars.a * (2 + sin(IN.uv_MediumStars.x * IN.uv_MediumStars.y * 24 + _Time.z * 2) / 2) + 
				bigStars.a;
			
			o.Emission = background.rgb + starAlbedo * starAlpha;
		}

		ENDCG
	}
	FallBack "Diffuse"
}
