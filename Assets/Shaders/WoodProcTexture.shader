// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Unlit/WoodProcTexture"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Offset ("Offset", Range(0,100)) = 0
        _Color1 ("Color1", Color) = (0.598, 0.398, 0.199, 1)
        _Color2 ("Color2", Color) = (0.398, 0.198, 0, 1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

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
                float4 objectOrigin : TEXCOORD1;
                float2 screenPos : TEXCOORD2;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                o.objectOrigin = mul(unity_ObjectToWorld, float4(0.0,0.0,0.0,1.0) );
                o.screenPos = ComputeScreenPos(o.vertex);
                return o;
            }
            
            float4 _Color1;
            float4 _Color2;
            float _Offset;
            
            float2 hash( float2 x ) // Noise functions by inigo quilez
                {
                    const float2 k = float2( 0.3183099, 0.3678794 );
                    x = x*k + k.yx;
                    return -1.0 + 2.0*frac( 16.0 * k*frac( x.x*x.y*(x.x+x.y)) );
                }

            float noise( in float2 p )
            {
                float2 i = floor( p );
                float2 f = frac( p );
                
                float2 u = f*f*(3.0-2.0*f);

                float val = lerp( lerp( dot( hash( i + float2(0.0,0.0) ), f - float2(0.0,0.0) ), 
                                 dot( hash( i + float2(1.0,0.0) ), f - float2(1.0,0.0) ), u.x),
                            lerp( dot( hash( i + float2(0.0,1.0) ), f - float2(0.0,1.0) ), 
                                 dot( hash( i + float2(1.0,1.0) ), f - float2(1.0,1.0) ), u.x), u.y);
                
                return val + 0.5;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                
                // Normalized pixel coordinates (from 0 to 1)
                i.uv = float2(i.uv.x + i.screenPos.x * 10, i.uv.y);
                
                float jx = 1.0 * noise(float2(i.uv.x, i.uv.y));
                
                // noise
                i.uv += -0.5 + noise(float2(i.uv.x, i.uv.y + jx));

                // color bands
                float3 col3 = _Color1.rgb;
                float3 col2 = (_Color1.rgb + _Color2.rgb)/2;
                float3 col1 = _Color2.rgb;
                float3 col;
                i.uv.y = frac(i.uv.y*8.0);
                if (i.uv.y < 0.33) 
                {
                    col = col1;
                } else if (i.uv.y < 0.67)
                {
                    col = col2;
                } else if (i.uv.y <= 1.0){
                    col = col3;
                } else {
                    col = float3(0.941, 0.474, 0.945);
                }
                                    
                return fixed4(col, 1);
            }
            ENDCG
        }
    }
}
