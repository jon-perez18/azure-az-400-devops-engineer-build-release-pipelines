targetScope = 'subscription'

var policyName = guid('somethingUniqueForYou')

resource applicationInsightsNoLocalAuthentication 'Microsoft.Authorization/policyDefinitions@2023-04-01' = {
  name: policyName
  properties: {
    displayName: 'Application Insights should have local authentication methods disabled'
    mode: 'All'
    version: '1.0.0'
    parameters: {
      effect: {
        type: 'String'
        allowedValues: [ 'Audit', 'Deny', 'Disabled' ]
      }
    }
    policyRule: {
      if: {
        allOf: [
          {
            field: 'type'
            equals: 'Microsoft.Insights/components'
          }
          {
            field: 'Microsoft.Insights/components/DisableLocalAuth'
            notEquals: true
          }
        ]
      }
      then: {
        effect: '[parameters(\'effect\')]'
      }
    }
  }
}
