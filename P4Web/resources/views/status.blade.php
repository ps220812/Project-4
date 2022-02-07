@extends('layouts.layout')
@section('title')
    {{ __('Homepage') }}
@endsection
@section('content')
    <body class="antialiased">
        <div style="display: flex;">
            <div style="margin:10px">
                U heeft besteld:
                {{$order->pizza_id}}
            </div>
            <div style="margin:10px">
                Uw bestelling is nu {{$order->status_id}}
            </div>
        </div>
    </body>
@endsection
