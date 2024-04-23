#version 330 core
out vec4 FragColor;

in vec2 TexCoords;
in vec3 vNormal;
in vec3 FragPos;
in mat4 vmodel;

//uniform sampler2D texture_diffuse1;
uniform vec3 lightPos;
uniform vec3 viewPos;


void main()
{   
    //vec3 Normal = mat3(transpose(inverse(vmodel))) * vNormal;  
    vec3 Normal = vNormal;  
    vec3 objectColor=vec3(1.0f,0.5f,0.3f);
    vec3 lightColor=vec3(1.0f,1.0f,1.0f);
   // ambient
    float ambientStrength = 0.1;
    vec3 ambient = ambientStrength * lightColor;
  	
    // diffuse 
    vec3 norm = normalize(Normal);
    vec3 lightDir = normalize(lightPos - FragPos);
    float diff = max(0,dot(norm, lightDir));
    vec3 diffuse = diff * lightColor;
    
    // specular
    float specularStrength = 0.5;
    vec3 viewDir = normalize(viewPos - FragPos);
    vec3 reflectDir = reflect(-lightDir, norm);  
    float spec = pow(max(0,dot(viewDir, reflectDir)), 32);
    vec3 specular = specularStrength * spec * lightColor;
        
    vec3 result = (ambient + diffuse ) * objectColor+ specular;
    //vec3 result = specular;
    FragColor = vec4(result, 1.0);
}

