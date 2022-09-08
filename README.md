# HousingManagementSystemApi
Housing Management System API

## Configuration
Set environment variable `UNIVERSAL_HOUSING_CONNECTION_STRING` with a value of a connection string to Universal Housing database, i.e.
```
export UNIVERSAL_HOUSING_CONNECTION_STRING='Server=universal.lan;User Id=HousingRepairsOnline;Password=MyStrongPassword;Database=universalHousingDb'
```
This environment variable is mandatory and not setting it will cause the application to not start. 

## Copilot
Services running in each environment run in separate AWS accounts, however all services are deployed by pipelines from the build and deploy account.

DONT run `copilot svc deploy` or any other copilot command from any other account than `rnd-bnd`. 

Before running any copilot commands run this

1. Define AWS profile env var `export AWS_PROFILE=rnd-bnd`
2. Authenticate with AWS `aws sso login`
