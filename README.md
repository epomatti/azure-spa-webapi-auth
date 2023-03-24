# azure-frontend-staticwebapps-backend-appservices

## Local Development

```sh
az ad sp create-for-rbac --name app-local-development

az ad app update --id <application_id> --web-redirect-urls http://localhost:5053/.auth/login/aad/callback  --enable-id-token-issuance

az ad group create \
    --display-name Developers \
    --mail-nickname Developers  \
    --description "Local development"

az ad sp list \
    --filter "startswith(displayName, 'app-local-development')" \
    --query "[].{id:id, displayName:displayName}" \
    --output table

az ad group member add \
    --group Developers \
    --member-id <object-id>
```


Add the variables to launch.json

