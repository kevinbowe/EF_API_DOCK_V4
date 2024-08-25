#	Docker Run (Image)
#	FILE	Docker_Run_Image_.zsh
#	PATH	./dotnet_EF_DOCK/EF_API_DOCK_V4/
################################################################################

## This creates a Container that references this Image.
##		FAIL -- Unable to find the image [ test-01:latest ]
docker run --rm -d -p 8080:8000/tcp --name test-01-container test-01:latest
                                                  MISSING    --------------
################################################################################
####	START Analysis

docker run 
	--rm 
			#	This causes the existing container to be discarded before a new one is created.
			#	'remove'
	-d 
			# Detached
			# This causes the Container to run in the background like a service.
	-p 8080:8000/tcp 
			# Published (Port)
			# This maps a public port (8080) to an internal container port (8000)
			# /tcp defines the transport type of port. This is the default transport.
			# Other transport types include udp and sctp

	--name test-01-container 
			# Assign a name to the container

	test-01:latest
			# This is a PARAMETER
			# This is the name of the Image that should be used by the Container.

