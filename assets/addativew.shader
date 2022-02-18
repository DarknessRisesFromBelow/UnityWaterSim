Shader "Hidden/addativew"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _col("Main Color", Color) = (0,0,0,0)
    }
    SubShader
    {
        
        Cull Back 

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            float4 sum;

           
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

            float4 _col;
            fixed4 frag (v2f i) : SV_Target
            {
                return _col;
            }
            ENDCG
        }
    }
}
