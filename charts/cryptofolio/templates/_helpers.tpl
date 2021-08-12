{{/*
Create chart name and version as used by the chart label.
*/}}
{{- define "cryptofolio.chart" -}}
{{- printf "%s-%s" .Chart.Name .Chart.Version | replace "+" "_" | trunc 63 | trimSuffix "-" }}
{{- end }}

{{/*
Collector job name.
*/}}
{{- define "cryptofolio-collector-job.name" -}}
{{- .Values.jobs.collector.nameOverride | trunc 63 | trimSuffix "-" }}
{{- end }}

{{/*
Collector job fullname.
*/}}
{{- define "cryptofolio-collector-job.fullname" -}}
{{- if .Values.jobs.collector.fullnameOverride }}
{{- .Values.jobs.collector.fullnameOverride | trunc 63 | trimSuffix "-" }}
{{- else }}
{{- $name := .Values.jobs.collector.nameOverride }}
{{- if contains $name .Release.Name }}
{{- .Release.Name | trunc 63 | trimSuffix "-" }}
{{- else }}
{{- printf "%s-%s" .Release.Name $name | trunc 63 | trimSuffix "-" }}
{{- end }}
{{- end }}
{{- end }}

{{/*
Collector job common labels.
*/}}
{{- define "cryptofolio-collector-job.labels" -}}
helm.sh/chart: {{ include "cryptofolio.chart" . }}
{{ include "cryptofolio-collector-job.selectorLabels" . }}
{{- if .Chart.AppVersion }}
app.kubernetes.io/version: {{ .Chart.AppVersion | quote }}
{{- end }}
app.kubernetes.io/managed-by: {{ .Release.Service }}
{{- end }}

{{/*
Collector job selector labels.
*/}}
{{- define "cryptofolio-collector-job.selectorLabels" -}}
app.kubernetes.io/name: {{ include "cryptofolio-collector-job.name" . }}
app.kubernetes.io/instance: {{ .Release.Name }}
{{- end }}

{{/*
Create the name of the collector job service account to use.
*/}}
{{- define "cryptofolio-collector-job.serviceAccountName" -}}
{{- if .Values.jobs.collector.serviceAccount.create }}
{{- default (include "cryptofolio-collector-job.fullname" .) .Values.jobs.collector.serviceAccount.name }}
{{- else }}
{{- default "default" .Values.jobs.collector.serviceAccount.name }}
{{- end }}
{{- end }}