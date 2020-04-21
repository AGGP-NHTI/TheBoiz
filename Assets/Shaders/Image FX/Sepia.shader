// Retrieved from: https://danielilett.com/2019-04-27-tut1-0-smo-shaders-basics/
// Designed to give the screen a sepia-tone for sections that were in the past

Shader "Image FX/Sepia"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;

			fixed4 frag(v2f i) : SV_Target
			{
				float4 tex = tex2D(_MainTex, i.uv);

				half3x3 sepiaVals = half3x3
				(
					0.393, 0.349, 0.272, // Red
					0.769, 0.686, 0.534, // Green
					0.189, 0.168, 0.131 // Blue
				);

				half3 sepiaResult = mul(tex.rgb, sepiaVals);

				return half4(sepiaResult, tex.a);
            }
            ENDCG
        }
    }
}
