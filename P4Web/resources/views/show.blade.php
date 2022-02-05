@extends('layouts.layout')
@section('title')
    {{ __('Homepage') }}
@endsection
@section('content')
    <body class="antialiased">
        <div>
            <div style="margin: 10px">
                {{$pizza->pizza_name}}
            </div>
        </div>
    </body>
@endsection
