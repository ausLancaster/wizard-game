Shader "Unlit/TargetShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _TargetColour ("Target Colour", Color) = (0, 0, 0, 1)
    }
    SubShader
    {
        Tags {"Queue"="Transparent" "RenderType"="Transparent" }
        LOD 100
        Blend SrcAlpha OneMinusSrcAlpha

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
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _TargetColour;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                float2 d = i.uv - float2(0.5, 0.5);
                float r = length(d);
                float4 col = float4(0,0,0,0);
                float stripe = step(frac(r*5), 0.5);
                col += step(r, 0.5) * stripe * _TargetColour;
                
                return col;
            }
            ENDCG
        }
    }
}
