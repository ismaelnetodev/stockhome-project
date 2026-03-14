# StockHome

Controle de estoque doméstico com dashboard e leitura de cupons fiscais via OCR.

## Stack

- **Backend:** C# 10 / ASP.NET Core Web API / EF Core / SQLite
- **Frontend:** Next.js 16 / React / TypeScript / Tailwind CSS
- **OCR:** Azure AI Vision
- **Deploy:** Vercel (frontend) + Render (API) + Turso (banco produção)

## Estrutura
```
stockhome/
├── backend/
│   └── StockHome.API/
└── frontend/
    └── stockhome-web/
```

## Como rodar localmente

### Backend
```bash
cd backend/StockHome.API
dotnet run
```
API disponível em `https://localhost:5000` com Swagger em `/swagger`

### Frontend
```bash
cd frontend/stockhome-web
npm run dev
```
Frontend disponível em `http://localhost:3000`