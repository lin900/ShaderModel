#pragma once

#include<glad/glad.h>
#include<glm/glm.hpp>

#include<iostream>
#include<fstream>
#include<sstream>
#include<string>

class shader
{
public:
	unsigned int ID;

	shader(const char* vertexPath, const char* fragmentPath);
	void use();
	void setFloat(const std::string&name,float value)const;
	void setBool(const std::string&name,bool value)const;
	void setInt(const std::string&name,int value)const;
	void setVec3(const std::string& name, const glm::vec3 &value)const;
	void setMat4(const std::string& name, const glm::mat4& mat)const;
	void setVec3(const std::string& name, float x, float y, float z) const;
private:
    // utility function for checking shader compilation/linking errors.
    // ------------------------------------------------------------------------
	void checkCompileErrors(unsigned int shader, std::string type);
};