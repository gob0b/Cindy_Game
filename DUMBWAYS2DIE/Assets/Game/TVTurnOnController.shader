Shader "Custom/RetroTVStatic"
{
    Properties
    {
        _MainTex ("Base Texture", 2D) = "white" { }
        _StaticAmount ("Static Amount", Range(0, 1)) = 0.5
        _Fade ("Fade", Range(0, 1)) = 0.0
        _TimeOffset ("Time Offset", Range(0, 1)) = 0.0
    }
    
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        
        Pass {
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
            
            uniform float _StaticAmount;
            uniform float _Fade;
            uniform float _TimeOffset;
            uniform float2 _MainTex_TexelSize;
            
            float noise(float2 uv)
            {
                return frac(sin(dot(uv.xy + _TimeOffset, float2(12.9898, 78.233))) * 43758.5453);
            }

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }
            
            half4 frag(v2f i) : SV_Target
            {
                float noiseValue = noise(i.uv * 10.0) * _StaticAmount;
                half4 baseColor = tex2D(_MainTex, i.uv);
                baseColor.rgb += noiseValue; // Add noise to base texture
                
                // Apply fade
                baseColor.a *= _Fade;
                
                return baseColor;
            }
            ENDCG
        }
    }

    FallBack "Diffuse"
}









