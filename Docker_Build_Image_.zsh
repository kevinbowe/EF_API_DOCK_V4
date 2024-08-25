#	Docker Build (Image)
#	FILE	Docker_Build_Image_.zsh
#	PATH	./dotnet_EF_DOCK/EF_API_DOCK_V4/
################################################################################

## This builds the Image which references THIS file
##
docker image build --pull --file '/Users/kevinbowe/Projects/Analysis/dotnet_EF_DOCK/EF_API_DOCK_V4/Dockerfile' --tag 'test-01:latest' --label 'com.microsoft.created-by=visual-studio-code' --platform 'linux/amd64' '/Users/kevinbowe/Projects/Analysis/dotnet_EF_DOCK/EF_API_DOCK_V4'

################################################################################
####	START Analysis
docker image build 

	--pull 
				# Always attempt to pull all referenced images
				# This insures that the Latest image is always used.
				#		This can be an issue where a local image is obsolete.

	--file '/Users/kevinbowe/Projects/Analysis/dotnet_EF_DOCK/EF_API_DOCK_V4/Dockerfile' 
				# --- This is an OPTION
				# The path to the Dockerfile - The dockerfile name is included.
				# The file name can be different. (eg: dev-Dockerfile)
				#
				# If this arg is NOT provided, the Dockerfile in the current project 
				# 		root folder will be used. The file name must be Dockerfile.
				#
				# DOCKER DOCS -- Specifies the filepath of the Dockerfile to use. 
				#		If unspecified, a file named Dockerfile at the root of the build context is used by default.
	
	--tag 'test-01:latest' 
				# Name and optionally a tag (format: name:tag)
				# Where 
				# 	[ test-01 ] == the name of the image
				# 	[ latest ] == the tag of the image
				# "latest" will be added if no tag is provided.
	
	--label 'com.microsoft.created-by=visual-studio-code' 
				# Set metadata for an image
				# This is a KVP [ <the_key>=<the_value> ]
				# Multiple --labels are allowed.

	
	--platform 'linux/amd64' 
				# Set target platform for build
				By default, the platform of the host will be used UNLESS it is defined in the Dockerfile.
	
	'/Users/kevinbowe/Projects/Analysis/dotnet_EF_DOCK/EF_API_DOCK_V4'
				# --- This is a PARAMETER
				# This is the location of the Dockerfile.
				# This is commonly just a period [  .  ]
				# NOTE -- this is a complete path. - Not relative.


################################################################################
##		EXPERIMENTAL VERSIONS

###	Reference - WORKS
docker image build --pull --file '/Users/kevinbowe/Projects/Analysis/dotnet_EF_DOCK/EF_API_DOCK_V4/Dockerfile' --tag 'test-01:latest' --label 'com.microsoft.created-by=visual-studio-code' --platform 'linux/amd64' '/Users/kevinbowe/Projects/Analysis/dotnet_EF_DOCK/EF_API_DOCK_V4'

These OPTIONS can be removed without any negative consequences.
	--file
	--label
	--platform
This PARAMETER can be removed without negative consequences.
	The location of the Dockerfile (last parameter)
Add '.' period to replace the docker file reference. This is required.


##		WORKS
docker image build   \
--pull   \
\
--file '/Users/kevinbowe/Projects/Analysis/dotnet_EF_DOCK/EF_API_DOCK_V4/Dockerfile'   \
\
--tag 'test-01:latest'  \
\
--label 'com.microsoft.created-by=visual-studio-code'  \
\
--platform 'linux/amd64'  \
\
'/Users/kevinbowe/Projects/Analysis/dotnet_EF_DOCK/EF_API_DOCK_V4'


##		WORKS
docker image build  --pull   \
--tag 'test-02:latest'  \
--platform 'linux/amd64'  \
.


##		WORKS
docker image build  --pull   \
--tag 'test-02:latest'  \
.

##		WORKS
docker image build --pull --tag 'test-02:latest' .

